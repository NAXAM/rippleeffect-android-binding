using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace RippleEffectQs
{
    public class CustomListViewAdapter: BaseAdapter
    {
        private  List<string> textArrayList;
        private  LayoutInflater layoutInflater;

    public CustomListViewAdapter( Context context)
        {
            this.layoutInflater = LayoutInflater.From(context);
            this.textArrayList = new List<string>();
        }

        public override int Count =>  textArrayList.Count();

        public override Java.Lang.Object GetItem(int position)
        {
            return textArrayList[position];
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ViewHolder viewHolder;

            if (convertView == null)
            {
                convertView = layoutInflater.Inflate(Resource.Layout.row_view, parent, false);
                viewHolder = new ViewHolder(convertView);
                //convertView.Tag=viewHolder;
            }
            else
            {
                // viewHolder = (ViewHolder)convertView.Tag;
                viewHolder = new ViewHolder(convertView);

            }

            viewHolder.textView.Text=textArrayList[position];

            return convertView;
        }

        public void updateList(List<string> stringArrayList)
        {
            this.textArrayList.Clear();
            this.textArrayList.AddRange(stringArrayList);
            this.NotifyDataSetChanged();
        }

        private class ViewHolder  
        {
           public TextView textView;

            public ViewHolder(View v)
            {
                textView = (TextView)v.FindViewById(Resource.Id.text);
            }
        }
    }
}