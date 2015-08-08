using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace C15_Ex01_Saggi_032493124_Maor_201111606
{
	public partial class FormMain : Form
	{
        public List<PostFilterGroup> m_PostFilterGroups;

		private const string k_ApplicationId = "1444340485893858";

		private static readonly string[] sr_RequiredPermissions = 
		{
			"user_about_me",
			"user_friends",
			"publish_actions",
			"user_events",
			"user_posts",
			"user_photos",
			"user_status"
		};

		private static void saveAccessToken(string i_AccessToken)
		{
			Properties.Settings.Default.LastKnownAccessToken = i_AccessToken;
			Properties.Settings.Default.Save();
		}

		private static string loadLastKnownAccessToken()
		{
			return Properties.Settings.Default.LastKnownAccessToken;
		}

		private User m_LoggedInUser;

		private UserPaths m_UserPaths;

		public FormMain()
		{
            this.m_PostFilterGroups = new List<PostFilterGroup>();
			InitializeComponent();
		}

		private void logIn()
		{
			string lastKnownAccessToken = loadLastKnownAccessToken();
			LoginResult result = null;
			if (!string.IsNullOrEmpty(lastKnownAccessToken))
			{
				result = FacebookService.Connect(lastKnownAccessToken);
			}

			if (result == null || string.IsNullOrEmpty(result.AccessToken))
			{
				result = FacebookService.Login(k_ApplicationId, sr_RequiredPermissions);
			}

			if (string.IsNullOrEmpty(result.AccessToken))
			{
				MessageBox.Show(result.ErrorMessage);
			}
			else
			{
				m_LoggedInUser = result.LoggedInUser;
				m_UserPaths = new UserPaths(m_LoggedInUser);
				saveAccessToken(result.AccessToken);
			}
		}

		private void buttonLogIn_Click(object i_Sender, EventArgs i_Args)
		{
			this.logIn();
			if (m_LoggedInUser != null)
			{
				enableControls();
				loadPostFilters();
				fetchAllInformation();
			}
		}

		private void enableControls()
		{
			textBoxStatus.Enabled = true;
			buttonFetchNewsFeed.Enabled = true;
			buttonFetchCheckIns.Enabled = true;
			buttonFetchEvents.Enabled = true;
			buttonSetStatus.Enabled = true;
			buttonFilterSettings.Enabled = true;
			this.buttonCannedPost.Enabled = true;
			checkBoxShowFiltered.Enabled = true;
			listBoxEvents.Enabled = true;
			listBoxCheckins.Enabled = true;
			listBoxNewsFeed.Enabled = true;
		}

		private void fetchAllInformation()
		{
			fetchProfilePicture();
			fetchNewsFeed();
			fetchEvents();
			fetchCheckIns();
		}

		private void fetchProfilePicture()
		{
			pictureSmallProfile.ImageLocation = m_LoggedInUser.PictureSmallURL;
		}

		private void fetchCheckIns()
		{
			listBoxCheckins.Items.Clear();
			foreach (Checkin checkin in m_LoggedInUser.Checkins)
			{
				listBoxCheckins.Items.Add(checkin.Place.Name);
			}
		}

		private void fetchEvents()
		{
			listBoxEvents.DataSource = m_LoggedInUser.Events;
		}

        private void fetchNewsFeed()
        {
            if (m_LoggedInUser != null)
            {
                if (!checkBoxShowFiltered.Checked)
                {
                    listBoxNewsFeed.DataSource = m_LoggedInUser.NewsFeed;
                }
                else
                {
                    FacebookObjectCollection<Post> promotedPostCollection = new FacebookObjectCollection<Post>();
                    FacebookObjectCollection<Post> demotedPostCollection = new FacebookObjectCollection<Post>();
                    FacebookObjectCollection<Post> nonePriorityPostCollection = new FacebookObjectCollection<Post>();
                    foreach (Post post in m_LoggedInUser.NewsFeed)
                    {
						ePostPriority postPriority = ePostPriority.None;
                        foreach (PostFilterGroup filterGroup in this.m_PostFilterGroups)
                        {
                            if (filterGroup.IsMatch(post))
                            {
								postPriority = (ePostPriority)Math.Min((int)filterGroup.PostPriority, (int)postPriority);
                            }
                        }

	                    switch (postPriority)
	                    {
		                    case ePostPriority.Demoted:
			                    demotedPostCollection.Add(post);
			                    break;
		                    case ePostPriority.Promoted:
			                    promotedPostCollection.Add(post);
			                    break;
		                    case ePostPriority.None:
			                    nonePriorityPostCollection.Add(post);
			                    break;
	                    }
                    }

                    FacebookObjectCollection<Post> result = new FacebookObjectCollection<Post>();
                    foreach (Post post in promotedPostCollection)
                    {
                        result.Add(post);
                    }

                    foreach (Post post in nonePriorityPostCollection)
                    {
                        result.Add(post);
                    }

                    foreach (Post post in demotedPostCollection)
                    {
                        result.Add(post);
                    }

	                listBoxNewsFeed.DataSource = result;
                }
            }
        }
		
		private void listBoxEvents_SelectedIndexChanged(object i_Sender, EventArgs i_Args)
		{
			if (listBoxEvents.SelectedItems.Count == 1)
			{
				Event selectedEvent = listBoxEvents.SelectedItem as Event;
				if (selectedEvent != null)
				{
					this.pictureBoxEvent.LoadAsync(selectedEvent.PictureNormalURL);
				}
			}
		}

		private void buttonFetchCheckIns_Click(object i_Sender, EventArgs i_Args)
		{
			this.fetchCheckIns();
		}

		private void buttonFetchEvents_Click(object i_Sender, EventArgs i_Args)
		{
			this.fetchEvents();
		}

		private void buttonFetchNewsFeed_Click(object i_Sender, EventArgs i_Args)
		{
			this.fetchNewsFeed();
		}

		private void buttonSetStatus_Click(object i_Sender, EventArgs i_Args)
		{
			string statusText = textBoxStatus.Text.Trim();
			if (!string.IsNullOrEmpty(statusText))
			{
				Status status = m_LoggedInUser.PostStatus(textBoxStatus.Text);
				MessageBox.Show(@"Status Posted! ID: " + status.Id);
			}
		}

        private void buttonFilterSettings_Click(object i_Sender, EventArgs i_Args)
        {
            FormFilterSettings filterSettingsDialog = new FormFilterSettings();
            filterSettingsDialog.PostFilterGroup = this.m_PostFilterGroups;
            filterSettingsDialog.ShowDialog();
	        savePostFilters();
        }


		private void savePostFilters()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<PostFilterGroup>));
			using (TextWriter writer = new StreamWriter(m_UserPaths.PostFiltersPath))
			{
				serializer.Serialize(writer, m_PostFilterGroups);
			}
		}

        private void loadPostFilters()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<PostFilterGroup>));
			if (File.Exists(m_UserPaths.PostFiltersPath))
	        {
				using (TextReader reader = new StreamReader(m_UserPaths.PostFiltersPath))
		        {
			        m_PostFilterGroups = (List<PostFilterGroup>)serializer.Deserialize(reader);
		        }
	        }
	        else
	        {
		        m_PostFilterGroups = new List<PostFilterGroup>();
	        }
        }

        private void checkBoxShowFiltered_CheckedChanged(object i_Sender, EventArgs i_Args)
        {
            fetchNewsFeed();
        }

		private void buttonCannedPost_Click(object sender, EventArgs e)
		{
			FormSelectCannedPost form = new FormSelectCannedPost();
			form.CannedPostsDirectoryPath = m_UserPaths.CannedPostsDirectory;
            form.m_LoggedInUser = m_LoggedInUser;
			form.ShowDialog();
		}
	}
}
