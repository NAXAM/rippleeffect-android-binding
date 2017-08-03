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
using Android.Support.V7.Widget;
using Java.Util;

namespace RippleEffectQs
{
    public class CustomAdapter: RecyclerView.Adapter
    {
        private  List<string> textArrayList;
        private OnTapListener onTapListener;
        public CustomAdapter()
        {
            this.textArrayList = new List<string>();
        }

        public override int ItemCount =>  textArrayList.Count();

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            holder.ItemView.Click += (s, e) =>
            {
                if (onTapListener != null)
                    onTapListener.onTapView(position);

            };
            ((ViewHolder)holder).textView.Text=(string)textArrayList[position];

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View v = LayoutInflater.From(parent.Context)
                 .Inflate(Resource.Layout.row_view, null);

            return new ViewHolder(v);
        }
        public void updateList(List<string>  stringArrayList)
        {
            this.textArrayList.Clear();
            this.textArrayList.AddRange(stringArrayList);
            this.NotifyDataSetChanged();
        }

        public void setOnTapListener(OnTapListener onTapListener)
        {
            this.onTapListener = onTapListener;
        }

        public  class ViewHolder : RecyclerView.ViewHolder
        {
             public TextView textView;

            public ViewHolder(View v): base(v)
            {
                
                textView = (TextView)v.FindViewById(Resource.Id.text);
            }
        }
       
    }
}