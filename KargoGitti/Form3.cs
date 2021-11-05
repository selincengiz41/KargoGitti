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
    public partial class Form3 : Form
    {

        List<Koordinat> noktalar = new List<Koordinat>();
        List<GMap.NET.PointLatLng> points = new List<GMap.NET.PointLatLng>();
        new GMap.NET.WindowsForms.GMapOverlay routes = new GMap.NET.WindowsForms.GMapOverlay("Rotalar");
        new GMap.NET.WindowsForms.GMapOverlay routes2 = new GMap.NET.WindowsForms.GMapOverlay("Rotalar");
        GMap.NET.PointLatLng point = new GMap.NET.PointLatLng();
        new GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay("markers");
        new GMap.NET.WindowsForms.GMapOverlay markers2 = new GMap.NET.WindowsForms.GMapOverlay("markers");
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "qb8xv0dnM3HGtFqQIJSgEWKA01eMuo1Gv7OVBv6j",
            BasePath = "https://clear-safeguard-329609-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            GMap.NET.MapProviders.GMapProviders.GoogleMap.ApiKey = AppConfig.Key;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl2.CacheLocation = @"cache";




            gMapControl2.Overlays.Remove(markers);
            gMapControl2.Overlays.Remove(routes);

            gMapControl2.DragButton = MouseButtons.Left;
            gMapControl2.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;


            gMapControl2.ShowCenter = false;
            gMapControl2.SetPositionByKeywords("İzmit,Türkiye");


            gMapControl2.MinZoom = 5;
            gMapControl2.MaxZoom = 100;
            gMapControl2.Zoom = 10;

            DataCekme();
            Harita();


        }
        private void Harita()
        {


            foreach (var item in noktalar)
            {

                

                var po = new GMap.NET.PointLatLng(item.Latitude, item.Longitude);

                var marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(po, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot);

                markers.Markers.Add(marker);
                gMapControl2.Overlays.Add(markers);

                points.Add(new GMap.NET.PointLatLng(Convert.ToDouble(item.Latitude), Convert.ToDouble(item.Longitude)));

            }


            foreach (var item in points)
            {
                Console.WriteLine("Points :" + item.Lat + "  " + item.Lng);
            }
            ShorthestPath();

        }

        private async void DataCekme()
        {

            points.Clear();
            noktalar.Clear();
            if (client == null)
            {
                Console.WriteLine("client null");
            }
            else
            {
                FirebaseResponse response = client.Get(@"Koordinat/");


                responseToKoordinat(response);
            }




        }
        private void responseToKoordinat(FirebaseResponse response)
        {
            char[] ignore = new char[1] { ',' };


            char[] delimiterChars = { '-' };
            foreach (var i in response.Body.ToString().Replace("},", "-").Replace("{", "").Replace("}", "").Split(delimiterChars))
            {

                Koordinat nokta = new Koordinat
                {
                    Latitude = Convert.ToDouble(i.ToString().Split(ignore)[0].Replace(".", ",").Substring(17, 17)),
                    Longitude = Convert.ToDouble(i.ToString().Split(ignore)[1].Replace(".", ",").Substring(12))

                };
                noktalar.Add(nokta);
            }


        }
        private double RotaBul(GMap.NET.PointLatLng bir, GMap.NET.PointLatLng iki)
        {
            var route = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRoute(bir, iki, true, true, 14);
            var uzaklık = route.Distance;
            return uzaklık;
        }
        private void ShorthestPath()
        {
            List<GMap.NET.PointLatLng> temp = new List<GMap.NET.PointLatLng>();
            temp.Clear();
            temp.AddRange(points);

            for (int i = 0; i < temp.Count - 1; i++)
            {

                double min = double.MaxValue;
                int minIndex = -1;

                for (int u = i + 1; u < temp.Count; u++)
                {

                    if (min > RotaBul(temp[i], temp[u]))
                    {

                        min = RotaBul(temp[i], temp[u]);
                        minIndex = u;
                    }

                }
                Sırala(temp, i + 1, minIndex);

            }



            Cizdir(temp);

        }
        private void ShorthestPath2()
        {
            List<GMap.NET.PointLatLng> temp = new List<GMap.NET.PointLatLng>();
            temp.Clear();
            temp.AddRange(points);

            for (int i = 0; i < temp.Count - 1; i++)
            {

                double min = double.MaxValue;
                int minIndex = -1;

                for (int u = i + 1; u < temp.Count; u++)
                {

                    if (min > RotaBul(temp[i], temp[u]))
                    {

                        min = RotaBul(temp[i], temp[u]);
                        minIndex = u;
                    }

                }
                Sırala(temp, i + 1, minIndex);

            }



            Cizdir2(temp);

        }

        private void Sırala(List<GMap.NET.PointLatLng> dizi1, int index1, int index2)
        {
            (dizi1[index1], dizi1[index2]) = (dizi1[index2], dizi1[index1]);

        }

        private void Cizdir(List<GMap.NET.PointLatLng> dizi)
        {
            for (int a = 0; a < dizi.Count - 1; a++)
            {

                var route = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRoute(dizi[a], dizi[a + 1], true, true, 14);
                var r = new GMap.NET.WindowsForms.GMapRoute(route.Points, "my routes");

                routes.Routes.Add(r);
                gMapControl2.Overlays.Add(routes);

            }

        }
        private void Cizdir2(List<GMap.NET.PointLatLng> dizi)
        {
      

            for (int a = 0; a < dizi.Count - 1; a++)
            {

                var route = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRoute(dizi[a], dizi[a + 1], true, true, 14);
                var r = new GMap.NET.WindowsForms.GMapRoute(route.Points, "my routes");

                routes2.Routes.Add(r);
                gMapControl2.Overlays.Add(routes2);

            }

        }
        public void EkleMarker(GMap.NET.PointLatLng p)
        {
           
            Console.WriteLine("MArker ekle fonk " + p.Lat + "  " + p.Lng);

            var marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(p, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot);
            markers.Markers.Add(marker);
            gMapControl2.Overlays.Add(markers);
            gMapControl2.Overlays.Remove(routes);
            points.Add(p);
            ShorthestPath();

        }
        public void SilinenPointliMap(List<GMap.NET.PointLatLng> yeniHal)
        {

            for (int i = 0; i < 100; i++)
            {

                gMapControl2.Overlays.Remove(routes);
                gMapControl2.Overlays.Remove(markers);
                markers.Clear();
                gMapControl2.Overlays.Clear();


            }


            points.Clear();
            points.AddRange(yeniHal);
            foreach (var yeni in yeniHal)
            {
                Console.WriteLine("Yeni hal :" + yeni.Lat + " " + yeni.Lng);
                var marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(yeni, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot);
                markers2.Markers.Add(marker);
                gMapControl2.Overlays.Add(markers2);

            }
            gMapControl2.Refresh();


            ShorthestPath2();
            gMapControl2.Refresh();

        }



    }
}
