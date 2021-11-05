using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System.Threading;

namespace KargoGitti
{
    public partial class Form2 : Form
    {
        List<Koordinat> noktalar = new List<Koordinat>();
        List<GMap.NET.PointLatLng> points = new List<GMap.NET.PointLatLng>();
        new GMap.NET.WindowsForms.GMapOverlay routes = new GMap.NET.WindowsForms.GMapOverlay("Rotalar");
        new GMap.NET.WindowsForms.GMapOverlay markers2 = new GMap.NET.WindowsForms.GMapOverlay("markers");
        new GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay("markers");
        Form3 form3 = new Form3();


        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "qb8xv0dnM3HGtFqQIJSgEWKA01eMuo1Gv7OVBv6j",
            BasePath = "https://clear-safeguard-329609-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            form3.Show();

            client = new FireSharp.FirebaseClient(config);
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            GMap.NET.MapProviders.GMapProviders.GoogleMap.ApiKey = AppConfig.Key;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl1.CacheLocation = @"cache";

            points.Clear();
            noktalar.Clear();
            gMapControl1.Overlays.Remove(markers);
            gMapControl1.Overlays.Remove(routes);



            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;


            gMapControl1.ShowCenter = false;
            gMapControl1.SetPositionByKeywords(KonumTxt.Text);


            gMapControl1.MinZoom = 5;
            gMapControl1.MaxZoom = 100;
            gMapControl1.Zoom = 10;

            DataCekme();


            foreach (var item in noktalar)
            {


                var po = new GMap.NET.PointLatLng(item.Latitude, item.Longitude);

                var marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(po, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot);

                markers.Markers.Add(marker);
                gMapControl1.Overlays.Add(markers);

                points.Add(new GMap.NET.PointLatLng(Convert.ToDouble(item.Latitude), Convert.ToDouble(item.Longitude)));

            }


            foreach (var item in points)
            {
                Console.WriteLine("Points :" + item.Lat + "  " + item.Lng);
            }
        }

        private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {


                var point = gMapControl1.FromLocalToLatLng(e.X, e.Y);
                double lat1 = point.Lat;
                double longt1 = point.Lng;




                LatTxt.Text = lat1 + " ";
                LngTxt.Text = longt1 + " ";



                var koordinat = new Koordinat
                {
                    Latitude = lat1,
                    Longitude = longt1,


                };

                DataEkle(koordinat);

                var marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(point, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot);
                markers.Markers.Add(marker);
                gMapControl1.Overlays.Add(markers);
                form3.EkleMarker(point);
            }
        }

        private async void DataEkle(Koordinat ka)
        {

            SetResponse response = await client.SetTaskAsync("Koordinat/" + noktaAdiTxt.Text, ka);
            Koordinat result = response.ResultAs<Koordinat>();
            MessageBox.Show("Kargo eklendi");


        }

        private async void DataCekme()
        {


            FirebaseResponse response = client.Get(@"Koordinat/");



            responseToKoordinat(response);




        }
        private void responseToKoordinat(FirebaseResponse response)
        {
            char[] ignore = new char[1] { ',' };
         

            char[] delimiterChars = { '-' };
            foreach (var i in response.Body.ToString().Replace("},", "-").Replace("{", "").Replace("}", "").Split(delimiterChars))
            {
                
                Koordinat nokta = new Koordinat
                {
                    Latitude = double.Parse(i.ToString().Split(ignore)[0].Replace(".", ",").Substring(17)),
                    Longitude = double.Parse(i.ToString().Split(ignore)[1].Replace(".",",").Substring(12))
                  
                };
                noktalar.Add(nokta);
            }


        }

        private void SilBtn_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = client.Get(@"Koordinat/" + noktaAdiTxt.Text);
            Koordinat obj = response.ResultAs<Koordinat>();

            for (int a = 0; a < points.Count - 1; a++)
            {

                if (points[a].Lat == obj.Latitude && points[a].Lng == obj.Longitude)
                {

                    points.RemoveAt(a);
                   
                }



            }
            form3.SilinenPointliMap(points);
            DatabaseSilAsync();

            for (int i = 0; i < 100; i++)
            {
                gMapControl1.Overlays.Remove(routes);
                gMapControl1.Overlays.Remove(markers);
                gMapControl1.Overlays.Clear();

            }

            foreach (var item in points)
            {
               
                var marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(item, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot);
                markers2.Markers.Add(marker);
                gMapControl1.Overlays.Add(markers2);

            }


        }

        private async Task DatabaseSilAsync()
        {
            FirebaseResponse response = await client.DeleteTaskAsync(@"Koordinat/" + noktaAdiTxt.Text);
            MessageBox.Show(noktaAdiTxt.Text + "  Kargosu teslim edildi");


        }

        
    }
}
