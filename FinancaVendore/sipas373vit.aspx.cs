using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinancaVendore.data
{
    public partial class sipas373vit : System.Web.UI.Page
    {
        FinancaVendore.Requirenments lidhesi;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lidhesi = new Requirenments();
                dropIndikator.DataSource = lidhesi.MerGrupIndikatore().Copy();
                dropIndikator.DataValueField = "nrrendor";
                dropIndikator.DataTextField = "IndGropu";
                dropIndikator.DataBind();

                dropRegjionet.DataSource = lidhesi.MerRegjione().Copy();
                dropRegjionet.DataTextField = "region";
                dropRegjionet.DataBind();

                dropVitet.DataSource = lidhesi.MerPeriudha().Copy();
                dropVitet.DataValueField = "nrrendor";
                dropVitet.DataTextField = "year";
                dropVitet.DataBind();

                chkNjesite.Items.Clear();
                chkIndikatoret.Items.Clear();
                grafiku.InnerHtml = "";

            }
        }

        protected void dropIndikator_SelectedIndexChanged(object sender, EventArgs e)
        {
            lidhesi = new Requirenments();
            chkIndikatoret.DataSource = lidhesi.MerIndikatoretEGrupit(dropIndikator.SelectedValue.ToString()).Copy();
            chkIndikatoret.DataValueField = "nrrendor";
            chkIndikatoret.DataTextField = "nomination";
            chkIndikatoret.DataBind();
            grafiku.InnerHtml = "";
        }

        protected void dropRegjionet_TextChanged(object sender, EventArgs e)
        {
            if (dropRegjionet.Text != null)
            {
                lidhesi = new Requirenments();
                chkNjesite.DataSource = lidhesi.merLguByRegion(dropRegjionet.Text.ToString()).Copy();
                chkNjesite.DataValueField = "nrrendor";
                chkNjesite.DataTextField = "lgu";
                chkNjesite.DataBind();
                grafiku.InnerHtml = "";
            }
        }

        protected void tegjitha_CheckedChanged(object sender, EventArgs e)
        {
            if (tegjitha.Checked)
            {
                dropRegjionet.Enabled = false;
                lidhesi = new Requirenments();
                chkNjesite.DataSource = lidhesi.merLgu().Copy();
                chkNjesite.DataValueField = "nrrendor";
                chkNjesite.DataTextField = "lgu";
                chkNjesite.DataBind();
                grafiku.InnerHtml = "";
            }
            else
            {
                dropRegjionet.Enabled = true;
                lidhesi = new Requirenments();
                chkNjesite.DataSource = lidhesi.merLguByRegion(dropRegjionet.Text.ToString()).Copy();
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
            string selectedValueNjesite = "";
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
            //////////////////////
            string selectedValueIndikatoret = "";
            foreach (ListItem item in chkIndikatoret.Items)
            {
                if (item.Selected)
                {
                    selectedValueIndikatoret += item.Value.ToString() + ",";
                }
            }
            if (selectedValueIndikatoret.Length == 0)
            {
                //throw error ska njesi vendore te zgjedhura
                //ErrorLabel.Text = "Zgjidhni te pakten nje Njesi Vendore";
                return;
            }
            ///////////////////////

            selectedValueNjesite = selectedValueNjesite.Substring(0, selectedValueNjesite.Length - 1);
            selectedValueIndikatoret = selectedValueIndikatoret.Substring(0, selectedValueIndikatoret.Length - 1);

            string selectedValueVitet =dropVitet.SelectedValue.ToString();
         
            if (dropIndikator.SelectedValue == null || dropIndikator.SelectedValue == "")
            {
                //throw error ska indikator
                //ErrorLabel.Text = "Nuk keni zgjedhur Treguesin";
                return;
            }
            lidhesi = new Requirenments();
            DataTable tedhenatPerGrafik = lidhesi.MerTeDhenat(selectedValueVitet, selectedValueNjesite, selectedValueIndikatoret).Copy();

            if (tedhenatPerGrafik.Rows.Count > 0)
            {
                string zevendesimi = "";


                string[] njesite = selectedValueNjesite.Split(',');
                string[] indikatoret = selectedValueIndikatoret.Split(',');

                zevendesimi += "['Indikatoret',";
                for (int i = 0; i < njesite.Length; i++)
                {
                    DataTable emriNjesis = lidhesi.MerLGUSipasIndex(njesite[i]).Copy();
                    if (emriNjesis.Rows.Count > 0)
                    {
                        zevendesimi += "'" + emriNjesis.Rows[0].ItemArray[0].ToString() + "'";
                    }
                    if (i < njesite.Length - 1)
                    {
                        zevendesimi += ",";
                    }
                }
                zevendesimi += "]," + Environment.NewLine;

                for (int j = 0; j < indikatoret.Length; j++)
                {
                    zevendesimi += "[";
                    DataTable emriIndikatorit = lidhesi.MerIndikatoretSipasIndex(indikatoret[j]).Copy();
                    if (emriIndikatorit.Rows.Count > 0)
                    {
                        zevendesimi += "'" + emriIndikatorit.Rows[0].ItemArray[0].ToString() + "'";
                    }
                    for (int k = 0; k < njesite.Length; k++)
                    {
                        for (int m = 0; m < tedhenatPerGrafik.Rows.Count; m++)
                        {
                            if (tedhenatPerGrafik.Rows[m].ItemArray[2].ToString().Equals(njesite[k]) && tedhenatPerGrafik.Rows[m].ItemArray[3].ToString().Equals(indikatoret[j]))
                            {
                                zevendesimi += "," + tedhenatPerGrafik.Rows[m].ItemArray[4].ToString();
                            }
                        }
                    }


                    zevendesimi += "],";
                }


                string s = File.ReadAllText(@"c:/data/a.txt");
                s = s.Replace("<%Title%>","Ecuria per Vitin: "+ dropVitet.Text);
                s = s.Replace("<%Subtitle%>","Grafiku gjeneruar sipas indikatoreve te zgjedhur.");
                grafiku.InnerHtml = s.Replace("<%data%>", zevendesimi);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //ErrorLabel.Text = "";
            grafiku.InnerHtml = "";
            string selectedValueNjesite = "";
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
            //////////////////////
            string selectedValueIndikatoret = "";
            foreach (ListItem item in chkIndikatoret.Items)
            {
                if (item.Selected)
                {
                    selectedValueIndikatoret += item.Value.ToString() + ",";
                }
            }
            if (selectedValueIndikatoret.Length == 0)
            {
                //throw error ska njesi vendore te zgjedhura
                //ErrorLabel.Text = "Zgjidhni te pakten nje Njesi Vendore";
                return;
            }
            ///////////////////////

            selectedValueNjesite = selectedValueNjesite.Substring(0, selectedValueNjesite.Length - 1);
            selectedValueIndikatoret = selectedValueIndikatoret.Substring(0, selectedValueIndikatoret.Length - 1);

            string selectedValueVitet = dropVitet.SelectedValue.ToString();

            if (dropIndikator.SelectedValue == null || dropIndikator.SelectedValue == "")
            {
                //throw error ska indikator
                //ErrorLabel.Text = "Nuk keni zgjedhur Treguesin";
                return;
            }
            lidhesi = new Requirenments();
            DataTable tedhenatPerGrafik = lidhesi.MerTeDhenat(selectedValueVitet, selectedValueNjesite, selectedValueIndikatoret).Copy();

            if (tedhenatPerGrafik.Rows.Count > 0)
            {
                string zevendesimi = "";


                string[] njesite = selectedValueNjesite.Split(',');
                string[] indikatoret = selectedValueIndikatoret.Split(',');

                zevendesimi += "['Njesite Vendore',";
                for (int i = 0; i < indikatoret.Length; i++)
                {
                    DataTable emriIndikatorit = lidhesi.MerIndikatoretSipasIndex(indikatoret[i]).Copy();
                    if (emriIndikatorit.Rows.Count > 0)
                    {
                        zevendesimi += "'" + emriIndikatorit.Rows[0].ItemArray[0].ToString() + "'";
                    }
                    if (i < indikatoret.Length - 1)
                    {
                        zevendesimi += ",";
                    }
                }
                zevendesimi += "]," + Environment.NewLine;

                for (int j = 0; j < njesite.Length; j++)
                {
                    zevendesimi += "[";
                    DataTable emriNjesise = lidhesi.MerLGUSipasIndex(njesite[j]).Copy();
                    if (emriNjesise.Rows.Count > 0)
                    {
                        zevendesimi += "'" + emriNjesise.Rows[0].ItemArray[0].ToString() + "'";
                    }
                    for (int k = 0; k < indikatoret.Length; k++)
                    {
                        for (int m = 0; m < tedhenatPerGrafik.Rows.Count; m++)
                        {
                            if (tedhenatPerGrafik.Rows[m].ItemArray[2].ToString().Equals(njesite[j]) && tedhenatPerGrafik.Rows[m].ItemArray[3].ToString().Equals(indikatoret[k]))
                            {
                                zevendesimi += "," + tedhenatPerGrafik.Rows[m].ItemArray[4].ToString();
                            }
                        }
                    }


                    zevendesimi += "],";
                }


                string s = File.ReadAllText(@"c:/data/a.txt");
                s = s.Replace("<%Title%>", "Ecuria per Vitin: " + dropVitet.Text);
                s = s.Replace("<%Subtitle%>", "Grafiku gjeneruar sipas indikatoreve te zgjedhur.");
                grafiku.InnerHtml = s.Replace("<%data%>", zevendesimi);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
              //ErrorLabel.Text = "";
            grafiku.InnerHtml = "";
            string selectedValueNjesite = "";
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
            //////////////////////
            string selectedValueIndikatoret = "";
            foreach (ListItem item in chkIndikatoret.Items)
            {
                if (item.Selected)
                {
                    selectedValueIndikatoret += item.Value.ToString() + ",";
                }
            }
            if (selectedValueIndikatoret.Length == 0)
            {
                //throw error ska njesi vendore te zgjedhura
                //ErrorLabel.Text = "Zgjidhni te pakten nje Njesi Vendore";
                return;
            }
            ///////////////////////

            selectedValueNjesite = selectedValueNjesite.Substring(0, selectedValueNjesite.Length - 1);
            selectedValueIndikatoret = selectedValueIndikatoret.Substring(0, selectedValueIndikatoret.Length - 1);

            string selectedValueVitet = dropVitet.SelectedValue.ToString();

            if (dropIndikator.SelectedValue == null || dropIndikator.SelectedValue == "")
            {
                //throw error ska indikator
                //ErrorLabel.Text = "Nuk keni zgjedhur Treguesin";
                return;
            }
            lidhesi = new Requirenments();
            DataTable tedhenatPerGrafik = lidhesi.MerTeDhenat(selectedValueVitet, selectedValueNjesite, selectedValueIndikatoret).Copy();

            if (tedhenatPerGrafik.Rows.Count > 0)
            {
                string zevendesimi = "";


                string[] njesite = selectedValueNjesite.Split(',');
                string[] indikatoret = selectedValueIndikatoret.Split(',');

                zevendesimi += "['Njesite Vendore',";
                for (int i = 0; i < indikatoret.Length; i++)
                {
                    DataTable emriIndikatorit = lidhesi.MerIndikatoretSipasIndex(indikatoret[i]).Copy();
                    if (emriIndikatorit.Rows.Count > 0)
                    {
                        zevendesimi += "'" + emriIndikatorit.Rows[0].ItemArray[0].ToString() + "'";
                    }
                    if (i < indikatoret.Length - 1)
                    {
                        zevendesimi += ",";
                    }
                }
                zevendesimi += "]," + Environment.NewLine;

                for (int j = 0; j < njesite.Length; j++)
                {
                    zevendesimi += "[";
                    DataTable emriNjesise = lidhesi.MerLGUSipasIndex(njesite[j]).Copy();
                    if (emriNjesise.Rows.Count > 0)
                    {
                        zevendesimi += "'" + emriNjesise.Rows[0].ItemArray[0].ToString() + "'";
                    }
                    for (int k = 0; k < indikatoret.Length; k++)
                    {
                        for (int m = 0; m < tedhenatPerGrafik.Rows.Count; m++)
                        {
                            if (tedhenatPerGrafik.Rows[m].ItemArray[2].ToString().Equals(njesite[j]) && tedhenatPerGrafik.Rows[m].ItemArray[3].ToString().Equals(indikatoret[k]))
                            {
                                zevendesimi += "," + tedhenatPerGrafik.Rows[m].ItemArray[4].ToString();
                            }
                        }
                    }


                    zevendesimi += "],";
                }


                string s = File.ReadAllText(@"c:/data/b.txt");
                s = s.Replace("<%Title%>", "Ecuria per Vitin: " + dropVitet.Text);
                s = s.Replace("<%Subtitle%>", "Grafiku gjeneruar sipas indikatoreve te zgjedhur.");
                grafiku.InnerHtml = s.Replace("<%data%>", zevendesimi);
            }
        }

       
    }
}