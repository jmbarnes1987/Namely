﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Namely.Core.Model;
using Namely.Utility;
using SQLite;
using Namely.Core.Repository;
using System.IO;
using Android.Graphics;
using static Android.Views.View;

namespace Namely.Adapters
{
    class BabyNameListAdapter : BaseAdapter<BabyName>, IOnClickListener
    {
        List<BabyName> babyNameList;
        Activity context;

        //RowView controls
        ImageView babyNameIcon;
        TextView babyName;
        TextView babyNamePronunciation;
        Button deleteName;
        Button editName;
        Bitmap imageBitmap;

        //Configuration Variables
        BabyName currentBabyName;
        View currentConvertView;
        int currentPosition;       

        public BabyNameListAdapter(Activity context, List<BabyName> items) : base()
        {
            this.context = context;
            this.babyNameList = items;
        }

        public override BabyName this[int position]
        {
            get
            {
                return babyNameList[position];
            }
        }

        public override int Count
        {
            get
            {
                return babyNameList.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return babyNameList[position].ID;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            currentPosition = position;
            currentBabyName = babyNameList[currentPosition];
            //REFACTOR: Replace dummy image
            imageBitmap = new ImageHelper().GetImageBitmapFromUrl("https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png");

            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.BabyNameRowView, null);
            }

            currentConvertView = convertView;

            FindViews();

            BindData();

            return convertView;
        }

        private void FindViews()
        {
            babyName = currentConvertView.FindViewById<TextView>(Resource.Id.babyNameTextView);
            babyNamePronunciation = currentConvertView.FindViewById<TextView>(Resource.Id.pronunciationTextView);
            babyNameIcon = currentConvertView.FindViewById<ImageView>(Resource.Id.babyNameImageView);
            deleteName = currentConvertView.FindViewById<Button>(Resource.Id.deleteNameButton);
            editName = currentConvertView.FindViewById<Button>(Resource.Id.editNameButton);
        }

        private void BindData()
        {
            babyName.Text = currentBabyName.Name;
            babyNamePronunciation.Text = currentBabyName.Pronunciation;
            babyNameIcon.SetImageBitmap(imageBitmap);
            deleteName.Tag = currentPosition;
            editName.Tag = currentPosition;
            currentConvertView.Tag = currentPosition;

            //Testing OnClick Listener
            deleteName.SetOnClickListener(this);
            editName.SetOnClickListener(this);
        }

        //private void HandleEvents()
        //{
        //    EventHandler EditName_Click = null;
        //    editName.Click += EditName_Click;
        //}

        //Testing OnClick Listener
        private IRowViewOnClickListener onClickListener;

        public interface IRowViewOnClickListener
        {
            void ItemClick(View v);
        }

        public void SetRowViewItemOnClickListener(IRowViewOnClickListener listener)
        {
            onClickListener = listener;
        }

        public void OnClick(View v)
        {
            onClickListener.ItemClick(v);
        }

    }
}

#region Testing/Old Code
//convertView.FindViewById<TextView>(Resource.Id.nickNamesTextView).Text = String.Join(", ", (item.NickNames is null ? new List<string>{"N/A"} : item.NickNames)); //Refactor
//convertView = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
//convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Name;

//Button deleteName;
//deleteName = convertView.FindViewById<Button>(Resource.Id.deleteNameButton);
//deleteName.Tag = position;

//deleteName.Click -= DeleteName_Click;
//deleteName.Click += DeleteName_Click;



//Button editName;
//editName = convertView.FindViewById<Button>(Resource.Id.editNameButton);
//editName.Tag = position;

//editName.Click -= EditName_Click;
//editName.Click += EditName_Click;

//var row = convertView.FindViewById(Resource.Layout.BabyNameRowView);
//row.Click += Row_Click;

////REFACTOR: There must be a way to put this logic into the Activity. 
////Refactor: DRY
//private void EditName_Click(object sender, EventArgs e)
//{
//    var index = (int)((Button)sender).Tag;

//    string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
//                                 "NamelyDb-DEV.db3");
//    //    SQLiteAsyncConnection newDb = new SQLiteAsyncConnection(dbPath);

//    //SQLiteAsyncConnection myConn = new SQLiteAsyncConnection(dbPath);
//    SQLiteConnection myConn = new SQLiteConnection(dbPath);
//    var dbHelper = new DbHelper(myConn);

//    //dbHelper.DeleteItemByName()
//}

////Refactor: DRY
//private void DeleteName_Click(object sender, EventArgs e)
//{

//    var index = (int)((Button)sender).Tag;

//    string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
//                                 "NamelyDb-DEV.db3");
//    //    SQLiteAsyncConnection newDb = new SQLiteAsyncConnection(dbPath);

//    //SQLiteAsyncConnection myConn = new SQLiteAsyncConnection(dbPath);
//    SQLiteConnection myConn = new SQLiteConnection(dbPath);
//    var dbHelper = new DbHelper(myConn);

//    //dbHelper.DeleteItemByName()
//}

//public override View GetView(int position, View convertView, ViewGroup parent)
//{
//    var item = items[position];

//    if (convertView == null)  
//    {
//        convertView = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
//    }

//    convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Name;

//    return convertView;
//}
#endregion