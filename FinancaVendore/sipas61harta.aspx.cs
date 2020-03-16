using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinancaVendore.data
{
    public partial class sipas61harta : System.Web.UI.Page
    {
        FinancaVendore.Requirenments lidhesi;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                lidhesi = new Requirenments();
                dropGrupTreguesi.DataSource = lidhesi.MerGrupIndikatore().Copy();
                dropGrupTreguesi.DataValueField = "nrrendor";
                dropGrupTreguesi.DataTextField = "IndGropu";
                dropGrupTreguesi.DataBind();

               
                dropViti.DataSource = lidhesi.MerPeriudha().Copy();
                dropViti.DataValueField = "nrrendor";
                dropViti.DataTextField = "year";
                dropViti.DataBind();

            }
        }

        protected void dropGrupTreguesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            lidhesi = new Requirenments();
            dropIndikatori.DataSource = lidhesi.MerIndikatoretEGrupit(dropGrupTreguesi.SelectedValue.ToString()).Copy();
            dropIndikatori.DataValueField = "nrrendor";
            dropIndikatori.DataTextField = "nomination";
            dropIndikatori.DataBind();

        }

        protected void dropIndikatori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropViti.SelectedValue != null)
            {
                if (dropViti.SelectedValue != "")
                {
                    LoadGraph();
                }
            }
        }

        protected void dropViti_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropIndikatori.SelectedValue != null)
            {
                if (dropIndikatori.SelectedValue != "")
                {
                    LoadGraph();
                }
            }
        }

        private void LoadGraph()
        {
            string data = "";//"{ \"hc-key\": \"BELSH\",\"value\": 156},{\"hc-key\":\"BERAT\",\"value\": 158}";
            //{ \"hc-key\": \"Belsh\",\"value\": 267.4},{ \"hc-key\": \"Berat\",\"value\": 16722.44},
            //{ \"hc-key\": \"Bulqizë\",\"value\": 446},{ \"hc-key\": \"Cërrik\",\"value\": 5125.35},
            //{ \"hc-key\": \"Delvinë\",\"value\": 1571.55},{ \"hc-key\": \"Devoll\",\"value\": 2347.97},{ \"hc-key\": \"Dibër\",\"value\": 4130},{ \"hc-key\": \"Divjakë\",\"value\": 5011.34},{ \"hc-key\": \"Dropulli\",\"value\": 4392.63},{ \"hc-key\": \"Durrës\",\"value\": 122584},{ \"hc-key\": \"Elbasan\",\"value\": 74472.63},{ \"hc-key\": \"Fier\",\"value\": 44344.91},{ \"hc-key\": \"Finiq\",\"value\": 2118.86},{ \"hc-key\": \"Fushë_Arrëz\",\"value\": 1567.5},{ \"hc-key\": \"Gjirokastër\",\"value\": 13583.4},{ \"hc-key\": \"Gramsh\",\"value\": 4477.25},{ \"hc-key\": \"Has\",\"value\": 778},{ \"hc-key\": \"Himarë\",\"value\": 3416.5},{ \"hc-key\": \"Kamëz\",\"value\": 29979.35},{ \"hc-key\": \"Kavajë\",\"value\": 18172.83},{ \"hc-key\": \"Këlcyrë\",\"value\": 945},{ \"hc-key\": \"Klos\",\"value\": 894.13},{ \"hc-key\": \"Kolonjë\",\"value\": 2981.47},{ \"hc-key\": \"Konispol\",\"value\": 1283.55},{ \"hc-key\": \"Korçë\",\"value\": 43221.26},{ \"hc-key\": \"Krujë\",\"value\": 25488.8},{ \"hc-key\": \"Kuçovë\",\"value\": 6806.54},{ \"hc-key\": \"Kukës\",\"value\": 2584},{ \"hc-key\": \"Kurbin\",\"value\": 5268.34},{ \"hc-key\": \"Lezhë\",\"value\": 9929.41},{ \"hc-key\": \"Libohovë\",\"value\": 620.57},{ \"hc-key\": \"Librazhd\",\"value\": 3792},{ \"hc-key\": \"Lushnjë\",\"value\": 21700.04},{ \"hc-key\": \"Malësi e Madhe\",\"value\": 2114.14},{ \"hc-key\": \"Maliq\",\"value\": 5018.51},{ \"hc-key\": \"Mallakaster\",\"value\": 21067.66},{ \"hc-key\": \"Mat\",\"value\": 5107.06},{ \"hc-key\": \"Memaliaj\",\"value\": 952.97},{ \"hc-key\": \"Mirditë\",\"value\": 1569.1},{ \"hc-key\": \"Patos\",\"value\": 21537.85},{ \"hc-key\": \"Peqin\",\"value\": 3438.55},{ \"hc-key\": \"Përmet\",\"value\": 3247},{ \"hc-key\": \"Pogradec\",\"value\": 14904.12},{ \"hc-key\": \"Poliçan\",\"value\": 2388.85},{ \"hc-key\": \"Prrenjas\",\"value\": 519},{ \"hc-key\": \"Pukë\",\"value\": 1813.4},{ \"hc-key\": \"Pustec\",\"value\": 212.36},{ \"hc-key\": \"Roskovec\",\"value\": 5042.17},{ \"hc-key\": \"Rrogozhinë\",\"value\": 5666.32},{ \"hc-key\": \"Sarandë\",\"value\": 13657.52},{ \"hc-key\": \"Selenicë\",\"value\": 6707.07},{ \"hc-key\": \"Shijak\",\"value\": 9024},{ \"hc-key\": \"Shkodër\",\"value\": 33257.22},{ \"hc-key\": \"Skrapar\",\"value\": 1649.03},{ \"hc-key\": \"Tepelenë\",\"value\": 2157.6},{ \"hc-key\": \"Tiranë\",\"value\": 406772.49},{ \"hc-key\": \"Tropojë\",\"value\": 939.94},{ \"hc-key\": \"Ura_Vajgurore\",\"value\": 4433.03},{ \"hc-key\": \"Vau I Dejës\",\"value\": 7461.57},{ \"hc-key\": \"Vlorë\",\"value\": 41223.78},{ \"hc-key\": \"Vorë\",\"value\": 8531.71}


            lidhesi = new Requirenments();
            DataTable tedhenatPerGrafik = lidhesi.MerTeDhenatGrupMunicipalityByPeriudha(dropViti.SelectedValue.ToString(),dropIndikatori.SelectedValue.ToString()).Copy();

            for (int i = 0; i < tedhenatPerGrafik.Rows.Count; i++ )
            {
                data += "{ \"hc-key\": \"" + tedhenatPerGrafik.Rows[i].ItemArray[0].ToString().ToUpper() + "\",\"value\": " + tedhenatPerGrafik.Rows[i].ItemArray[2].ToString() + "}";
                if (i < tedhenatPerGrafik.Rows.Count-1)
                {
                    data += ",";
                }
            }

            string s = File.ReadAllText(@"c:\data\d.txt");
            s = s.Replace("<%Title%>", "Shperndarja sipas 61 Bashkive per Indikatorin " + dropIndikatori.SelectedItem.Text +" gjate Vitit " + dropViti.SelectedItem.Text);
            s = s.Replace("<%color%>", "#eeeeee");
            s = s.Replace("<%data%>", data);
            form1.InnerHtml = s;
        }
    }
}