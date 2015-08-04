using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace C15_Ex01_Saggi_032493124_Maor_201111606
{
	public partial class FormMain : Form
	{
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

		private User m_LoggedInUser = null;

		public FormMain()
		{
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
				saveAccessToken(result.AccessToken);
				MessageBox.Show(string.Format("Hello {0}", result.LoggedInUser.Name));
			}
		}

		private void buttonLogIn_Click(object i_Sender, EventArgs i_Args)
		{
			this.logIn();
			if (m_LoggedInUser != null)
			{
				enableControls();
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
			listBoxNewsFeed.DataSource = m_LoggedInUser.NewsFeed;
		}

		private void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
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

		private void buttonFetchCheckIns_Click(object sender, EventArgs e)
		{
			this.fetchCheckIns();
		}

		private void buttonFetchEvents_Click(object sender, EventArgs e)
		{
			this.fetchEvents();
		}

		private void buttonFetchNewsFeed_Click(object sender, EventArgs e)
		{
			this.fetchNewsFeed();
		}

		private void buttonSetStatus_Click(object sender, EventArgs e)
		{
			string statusText = textBoxStatus.Text.Trim();
			if (!string.IsNullOrEmpty(statusText))
			{
				Status status = m_LoggedInUser.PostStatus(textBoxStatus.Text);
				MessageBox.Show("Status Posted! ID: " + status.Id);
			}
		}
	}
}
