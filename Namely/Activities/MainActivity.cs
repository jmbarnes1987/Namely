﻿using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using Namely.Core.Repository;
using SQLite;
using System.IO;
using System.Collections.Generic;
using Namely.Core.Model;

//REFACTOR: Need to rethink the data model, need to separate first/middle names, etc. Review code notes.
namespace Namely
{
    [Activity(Label = "Namely", MainLauncher = true, Icon = "@drawable/icon")]
    //[Activity(Label = "Namely")]
    public class MainActivity : Activity
    {
        private Button reviewDataButton;
        private Button syncDataButton;
        private Button nameExplorerButton;
        private Button firstNameButton;
        private Button middleNameButton;
        private EditText firstNameEditText;
        private EditText middleNameEditText;
        public static SQLiteConnection connection;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            CreateDatabase();
            FindViews();
            BindData();
            HandleEvents();
        }

        private void CreateDatabase()
        {
            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "NamelyDb-DEV.db3");

                var db = new SQLiteConnection(dbPath);
                db.CreateTable<BabyName>();

            }
            catch (Exception ex)
            {
                var debug = ex.Message + ex.InnerException;
                throw;
            }
        }

        private void FindViews()
        {
            reviewDataButton = FindViewById<Button>(Resource.Id.ReviewDataButton);
            syncDataButton = FindViewById<Button>(Resource.Id.SyncDataButton);
            nameExplorerButton = FindViewById<Button>(Resource.Id.NameExplorerButton);
            firstNameButton = FindViewById<Button>(Resource.Id.AddFNameButton);
            middleNameButton = FindViewById<Button>(Resource.Id.AddMNameButton);
            firstNameEditText = FindViewById<EditText>(Resource.Id.FirstNameEditText);
            middleNameEditText = FindViewById<EditText>(Resource.Id.MiddleNameEditText);
        }

        private void BindData()
        {
            //babyNameTextView.Text = selectedBabyName.Name;
            //nickNameTextView.Text = selectedBabyName.NickNames.ToString();
            //pronunciationTextView.Text = selectedBabyName.Pronunciation;
        }

        //REFACTOR: Finish Implementing Below:
        private void HandleEvents()
        {
            //nextbutton.click += nextbutton_click
            //likebutton.click += likebutton_click
            reviewDataButton.Click += ReviewButton_Click;
            syncDataButton.Click += SyncDataButton_Click;
            nameExplorerButton.Click += NameExplorerButton_Click;
            firstNameButton.Click += FirstNameButton_Click;
            middleNameButton.Click += MiddleNameButton_Click;
        }

        private void MiddleNameButton_Click(object sender, EventArgs e)
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                             "NamelyDb-DEV.db3");
            //    SQLiteAsyncConnection newDb = new SQLiteAsyncConnection(dbPath);

            //SQLiteAsyncConnection myConn = new SQLiteAsyncConnection(dbPath);
            SQLiteConnection myConn = new SQLiteConnection(dbPath);
            //var dbHelper = new DbHelper(myConn);
            var dbHelper = new DbHelper(myConn);

            dbHelper.SaveItem(new Core.Model.BabyName
            {
                Name = middleNameEditText.Text,
                History = "",
                Meaning = "",
                //NickNames = new List<string>(),
                Pronunciation = ""
            });
        }

        //REFACTOR: DRY, button click logic is almost identical
        private void FirstNameButton_Click(object sender, EventArgs e)
        {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                                 "NamelyDb-DEV.db3");

            SQLiteConnection myConn = new SQLiteConnection(dbPath);
            var dbHelper = new DbHelper(myConn);
            //var dbHelper = new DbHelper(connection);
            var test = firstNameEditText.Text;

            dbHelper.SaveItem(new Core.Model.BabyName
            {
                Name = firstNameEditText.Text,
                History = "",
                Meaning = "",
                //NickNames = new List<string>(),
                Pronunciation = ""
            });
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

            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                 "NamelyDb-DEV.db3");
            //    SQLiteAsyncConnection newDb = new SQLiteAsyncConnection(dbPath);

            SQLiteConnection myConn = new SQLiteConnection(dbPath);
            var dbHelper = new DbHelper(myConn);
            myConn.CreateTable<BabyName>();
        }

        private void ReviewButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(BabyNameExplorerActivity)); //Create the review activity and replace here.
            StartActivity(intent);
            //StartActivityForResult(); I could pass data back and forth with this
        }
    }
}

#region Old Code
//private TextView babyNameTextView;
//private TextView nickNameTextView;
//private TextView pronunciationTextView;

//private BabyName selectedBabyName;
//private BabyNameDataService dataService;

//Button testAppButton = FindViewById<Button>(Resource.Id.TestAppButton);
//TextView testAppEditText = FindViewById<EditText>(Resource.Id.TestAppEditText);

//testAppButton.Click += delegate { testAppEditText.Text = "testing"; };
//BabyNameDataService dataService = new BabyNameDataService();
//dataService = new BabyNameDataService();
//selectedBabyName = dataService.GetBabyNameByName("Jacob");

//private void nextbutton_click(sender, e)
//{ do something }

//private void likebutton_click(sender, e)
//{ do something }

//dbHelper.SaveItemAsync(new Core.Model.BabyName
//{
//    Name = firstNameEditText.Text,
//    History = "",
//    Meaning = "",
//    //NickNames = new List<string>(),
//    Pronunciation = ""
//});

//    SQLiteAsyncConnection newDb = new SQLiteAsyncConnection(dbPath);

//SQLiteAsyncConnection myConn = new SQLiteAsyncConnection(dbPath);

//dbHelper.SaveItemAsync(new Core.Model.BabyName
//{
//    Name = middleNameEditText.Text,
//    History = "",
//    Meaning = "",
//    //NickNames = new List<string>(),
//    Pronunciation = ""
//});
//string dbPath = "NamelyDb-DEV.db3";

//bool exists = File.Exists(dbPath);

//if (!exists)
//{    
//connection = new SQLiteConnection(dbPath);
//}
//else
//{
//    connection = new SQLiteConnection(dbPath);
//}
//public SQLiteConnection GetConnection()
//{
//    var dbName = "TestDB-DEV.db3";
//    var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
//    var path = Path.Combine(documentsPath, dbName);

//    var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
//    var connection = new SQLiteConnection(platform, path);

//    return connection;
//}
#endregion