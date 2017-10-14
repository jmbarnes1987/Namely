﻿using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace Namely
{
    [Activity(Label = "Namely", MainLauncher = true, Icon = "@drawable/icon")]
    //[Activity(Label = "Namely")]
    public class MainActivity : Activity
    {
        //private TextView babyNameTextView;
        //private TextView nickNameTextView;
        //private TextView pronunciationTextView;

        //private BabyName selectedBabyName;
        //private BabyNameDataService dataService;
        private Button reviewDataButton;
        private Button syncDataButton;
        private Button nameExplorerButton;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            //Button testAppButton = FindViewById<Button>(Resource.Id.TestAppButton);
            //TextView testAppEditText = FindViewById<EditText>(Resource.Id.TestAppEditText);

            //testAppButton.Click += delegate { testAppEditText.Text = "testing"; };
            //BabyNameDataService dataService = new BabyNameDataService();
            //dataService = new BabyNameDataService();
            //selectedBabyName = dataService.GetBabyNameByName("Jacob");

            FindViews();
            BindData();
            HandleEvents();
        }

        private void FindViews()
        {
            //babyNameTextView = FindViewById<TextView>(Resource.Id.babyNameTextView);
            //nickNameTextView = FindViewById<TextView>(Resource.Id.nickNamesTextView);
            //pronunciationTextView = FindViewById<TextView>(Resource.Id.pronunciationTextView);

            reviewDataButton = FindViewById<Button>(Resource.Id.ReviewDataButton);
            syncDataButton = FindViewById<Button>(Resource.Id.SyncDataButton);
            nameExplorerButton = FindViewById<Button>(Resource.Id.NameExplorerButton);
        }

        private void BindData()
        {
            //babyNameTextView.Text = selectedBabyName.Name;
            //nickNameTextView.Text = selectedBabyName.NickNames.ToString();
            //pronunciationTextView.Text = selectedBabyName.Pronunciation;

            //ImageHelper
            //Set ImageView
        }

        //Finish Implementing Below:
        private void HandleEvents()
        {
            //nextbutton.click += nextbutton_click
            //likebutton.click += likebutton_click
            reviewDataButton.Click += ReviewButton_Click;
            syncDataButton.Click += SyncDataButton_Click;
            nameExplorerButton.Click += NameExplorerButton_Click;
        }

        private void NameExplorerButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(BabyNameExplorerActivity));
            StartActivity(intent);
        }

        private void SyncDataButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(BabyNameExplorerActivity)); //Create the sync activity and replace here.
            StartActivity(intent);
        }

        private void ReviewButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(BabyNameExplorerActivity)); //Create the review activity and replace here.
            StartActivity(intent);
        }

        //private void nextbutton_click(sender, e)
        //{ do something }

        //private void likebutton_click(sender, e)
        //{ do something }
    }
}

