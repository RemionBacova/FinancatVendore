using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FinancaVendore.data
{
    public partial class _373ind : System.Web.UI.Page
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

                dropRegjione.DataSource = lidhesi.MerRegjione().Copy();
                dropRegjione.DataTextField = "region";
                dropRegjione.DataBind();

                chkVitet.DataSource = lidhesi.MerPeriudha().Copy();
                chkVitet.DataValueField = "nrrendor";
                chkVitet.DataTextField = "year";
                chkVitet.DataBind();

                chkNjesite.Items.Clear();

            }
        }
        protected void dropGrupTreguesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            lidhesi = new Requirenments();
            dropIndikatori.DataSource = lidhesi.MerIndikatoretEGrupit(dropGrupTreguesi.SelectedValue.ToString()).Copy();
            dropIndikatori.DataValueField = "nrrendor";
            dropIndikatori.DataTextField = "nomination";
            dropIndikatori.DataBind();
            grafiku.InnerHtml = "";
        }

        protected void dropRegjione_TextChanged(object sender, EventArgs e)
        {
            if (dropRegjione.Text != null)
            {
                lidhesi = new Requirenments();
                chkNjesite.DataSource = lidhesi.merLguByRegion(dropRegjione.Text.ToString()).Copy();
                chkNjesite.DataValueField = "nrrendor";
                chkNjesite.DataTextField = "lgu";
                chkNjesite.DataBind();
                grafiku.InnerHtml = "";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //ErrorLabel.Text = "";
            grafiku.InnerHtml = "";
            string selectedValueNjesite="";
            foreach (ListItem item in chkNjesite.Items)
            {
                if (item.Selected)
                {
                    selectedValueNjesite += item.Value.ToString() + ",";
                }
            }
            if (selectedValueNjesite.Length == 0)
            {
                //throw error ska njesi vendore te zgjedhura
                //ErrorLabel.Text = "Zgjidhni te pakten nje Njesi Vendore";
                return;
            }
            selectedValueNjesite = selectedValueNjesite.Substring(0, selectedValueNjesite.Length - 1);
            string selectedValueVitet = "";
            foreach (ListItem item in chkVitet.Items)
            {
                if (item.Selected)
                {
                    selectedValueVitet += item.Value.ToString() + ",";
                }
            }
            if (selectedValueVitet.Length == 0)
            {
                //throw error ska vite te zgjedhura
                //ErrorLabel.Text = "Zgjidhni te pakten nje Periudhe";
                return; 
            }
            selectedValueVitet = selectedValueVitet.Substring(0, selectedValueVitet.Length - 1);
            if (dropIndikatori.SelectedValue == null || dropIndikatori.SelectedValue == "")
            {
                //throw error ska indikator
                //ErrorLabel.Text = "Nuk keni zgjedhur Treguesin";
                return;
            }
            lidhesi = new Requirenments();
            DataTable tedhenatPerGrafik = lidhesi.MerTeDhenat(selectedValueVitet, selectedValueNjesite, dropIndikatori.SelectedValue.ToString()).Copy();

            if (tedhenatPerGrafik.Rows.Count > 0)
            {
                string zevendesimi = "";

                string[] vitet = selectedValueVitet.Split(',');
                string[] njesite = selectedValueNjesite.Split(',');

                zevendesimi += "['Vitet',";
                for (int i = 0; i < njesite.Length; i++)
                {
                    DataTable emriIndikatorit = lidhesi.MerLGUSipasIndex(njesite[i]).Copy();
                    if (emriIndikatorit.Rows.Count > 0)
                    {
                        zevendesimi += "'" + emriIndikatorit.Rows[0].ItemArray[0].ToString() + "'";
                    }
                    if (i < njesite.Length - 1)
                    {
                        zevendesimi += ",";
                    }
                }
                zevendesimi += "]," + Environment.NewLine;

                for (int j = 0; j < vitet.Length; j++)
                {
                    zevendesimi += "[";
                    DataTable emriIVitit = lidhesi.MerVitinSipasIndex(vitet[j]).Copy();
                    if (emriIVitit.Rows.Count > 0)
                    {
                        zevendesimi += "'"+emriIVitit.Rows[0].ItemArray[0].ToString()+"'";
                    }
                    for (int k = 0; k < njesite.Length; k++)
                    {
                        for (int m = 0; m < tedhenatPerGrafik.Rows.Count; m++)
                        {
                            if(tedhenatPerGrafik.Rows[m].ItemArray[2].ToString().Equals( njesite[k]))
                            {
                                zevendesimi += "," + tedhenatPerGrafik.Rows[m].ItemArray[4].ToString();
                            }
                        }
                    }


                    zevendesimi += "],";
                }


                string s = File.ReadAllText(@"c:/data/a.txt");
                grafiku.InnerHtml = s.Replace("<%data%>", zevendesimi);
            }
        }

        protected void tegjitha_CheckedChanged(object sender, EventArgs e)
        {
            if (tegjitha.Checked)
            {
                dropRegjione.Enabled = false;
                lidhesi = new Requirenments();
                chkNjesite.DataSource = lidhesi.merLgu().Copy();
                chkNjesite.DataValueField = "nrrendor";
                chkNjesite.DataTextField = "lgu";
                chkNjesite.DataBind();
                grafiku.InnerHtml = "";
            }
            else
            {
                dropRegjione.Enabled = true;
                lidhesi = new Requirenments();
                chkNjesite.DataSource = lidhesi.merLguByRegion(dropRegjione.Text.ToString()).Copy();
                chkNjesite.DataValueField = "nrrendor";
                chkNjesite.DataTextField = "lgu";
                chkNjesite.DataBind();
                grafiku.InnerHtml = "";
            }
        }

       

     
    }
}