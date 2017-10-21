﻿using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using Namely.Core.Model;
using Namely.Core.Service;
using Namely.Adapters;
using Android.Content;
using Namely.Core.Repository;
using System.IO;
using SQLite;
using System.Threading.Tasks;

namespace Namely
{
    [Activity(Label = "Baby Name Explorer")]
    //[Activity(Label = "Baby Name Explorer", MainLauncher = true)]
    public class BabyNameExplorerActivity : Activity
    {
        private ListView babyNameListView;
        private Task<List<BabyName>> getNames;
        private List<BabyName> allBabyNames;
        //private BabyNameDataService babyNameDataService;
        //private DbHelper dbHelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.BabyNameExplorerView);

            babyNameListView = FindViewById<ListView>(Resource.Id.babyNameListView);
            //babyNameDataService = new BabyNameDataService();
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                                         "NamelyDb-DEV.db3");
            //    SQLiteAsyncConnection newDb = new SQLiteAsyncConnection(dbPath);

            SQLiteAsyncConnection myConn = new SQLiteAsyncConnection(dbPath);
            var dbHelper = new DbHelper(myConn);
            //allBabyNames = babyNameDataService.GetAllBabyNames();
            getNames = dbHelper.GetItemsAsync();

            allBabyNames = getNames.Result;

            babyNameListView.Adapter = new BabyNameListAdapter(this, allBabyNames);

            babyNameListView.FastScrollEnabled = true;

            babyNameListView.ItemClick += BabyNameListView_ItemClick;
        }

        private void BabyNameListView_ItemClick (object sender, AdapterView.ItemClickEventArgs e)
        {
            var babyName = allBabyNames[e.Position];

            var intent = new Intent();
            intent.SetClass(this, typeof(BabyNameDetailActivity));
            Intent.PutExtra("selectedBabyName", babyName.Name);
        }
    }
}