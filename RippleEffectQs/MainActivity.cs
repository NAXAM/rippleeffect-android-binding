using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System.Collections.Generic;
using Com.Andexert.Library;
using Android.Support.V7.Widget;

namespace RippleEffectQs
{
    [Activity(Label = "RippleEffectQs", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/AppTheme")]
    public class MainActivity : ActionBarActivity
    {
        private bool isRecyclerview = false;
        private List<string> sourcesArrayList = new List<string>();
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            if (isRecyclerview)
                SetContentView(Resource.Layout.activity_main_recycler);
            else
                SetContentView(Resource.Layout.activity_main_list);

            RippleView rippleView = (RippleView)FindViewById(Resource.Id.rect);
            TextView textView = (TextView)FindViewById(Resource.Id.rect_child);
            Android.Support.V7.Widget.Toolbar toolbar = (Android.Support.V7.Widget.Toolbar)FindViewById(Resource.Id.actionbar);

            SetSupportActionBar(toolbar);
            rippleView.Click += (s, e) =>
            {


            };


            sourcesArrayList.Add("Samsung");
            sourcesArrayList.Add("Android");
            sourcesArrayList.Add("Google");
            sourcesArrayList.Add("Asus");
            sourcesArrayList.Add("Apple");
            sourcesArrayList.Add("Samsung");
            sourcesArrayList.Add("Android");
            sourcesArrayList.Add("Google");
            sourcesArrayList.Add("Asus");
            sourcesArrayList.Add("Apple");
            sourcesArrayList.Add("Samsung");
            sourcesArrayList.Add("Android");
            sourcesArrayList.Add("Google");
            sourcesArrayList.Add("Asus");
            sourcesArrayList.Add("Apple");


            if (isRecyclerview)
            {
                RecyclerView recyclerView = (RecyclerView)FindViewById(Resource.Id.recycler_view);
                recyclerView.HasFixedSize = true;
                RecyclerView.LayoutManager layoutManager = new LinearLayoutManager(this);
                recyclerView.SetLayoutManager(layoutManager);

                CustomAdapter customAdapter = new CustomAdapter();
                customAdapter.updateList(sourcesArrayList);
                customAdapter.setOnTapListener(new MyTap());


                recyclerView.SetAdapter(customAdapter);
            }
            else
            {
                ListView listView = (ListView)FindViewById(Resource.Id.listview);
                CustomListViewAdapter customListViewAdapter = new CustomListViewAdapter(this);
                customListViewAdapter.updateList(sourcesArrayList);
                listView.Adapter=customListViewAdapter;
                //listView.OnItemClickListener(new MyItemClick());
                listView.ItemClick += (s, e) =>
                {
                    // do something here later

                };
        
        }
    }
}
}

