using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinancaVendore
{
    public partial class teardhurat : System.Web.UI.Page
    {
        FinancaVendore.Requirenments lidhesi;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadioButtonList1.Items[0].Selected = true;
                merVitet();
                merRegjione();
                chkNjesite.Items.Clear();
                chkNjesite.DataSource = null;
                dropIndikatoret.DataSource = lidhesi.MerIndikatoretEGrupit("3").Copy();
                dropIndikatoret.DataValueField = "nrrendor";
                dropIndikatoret.DataTextField = "nomination";
                dropIndikatoret.DataBind();
                grafiku.InnerHtml = "";

            }
        }

        private void merVitet()
        {
            lidhesi = new Requirenments();
            chkVitet.DataSource = lidhesi.MerPeriudha().Copy();
            chkVitet.DataValueField = "nrrendor";
            chkVitet.DataTextField = "year";
            chkVitet.DataBind();
        }

        private void merRegjione()
        {
            lidhesi = new Requirenments();
            dropGrupNjesite.Enabled = true;
            dropGrupNjesite.DataSource = lidhesi.MerRegjione().Copy();
            dropGrupNjesite.DataTextField = "region";
            dropGrupNjesite.DataBind();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.Items[0].Selected)
            {

                dropGrupNjesite.Enabled = true;
                tegjitha.Enabled = true;
                tegjitha.Checked = false;
                merRegjione();
            }
            else
            {
                dropGrupNjesite.Enabled = false;
                tegjitha.Enabled = false;
                tegjitha.Checked = false;
                dropGrupNjesite.Items.Clear();
            }
            merNjesite();
        }

        private void merNjesite()
        {
            chkNjesite.Items.Clear();
            chkNjesite.DataSource = null;
            lidhesi = new Requirenments();
            if (RadioButtonList1.Items[0].Selected)
            {
                if (tegjitha.Checked)
                {
                    chkNjesite.DataSource = lidhesi.merLgu().Copy();
                    chkNjesite.DataValueField = "nrrendor";
                    chkNjesite.DataTextField = "lgu";
                    chkNjesite.DataBind();
                    grafiku.InnerHtml = "";
                }
                else
                {
                    chkNjesite.DataSource = lidhesi.merLguByRegion(dropGrupNjesite.Text.ToString()).Copy();
                    chkNjesite.DataValueField = "nrrendor";
                    chkNjesite.DataTextField = "lgu";
                    chkNjesite.DataBind();
                    grafiku.InnerHtml = "";
                }
            }
            else
            {
                chkNjesite.DataSource = lidhesi.MerMunicipality().Copy();
                chkNjesite.DataTextField = "municipality";
                chkNjesite.DataValueField = null;
                chkNjesite.DataBind();
            }
        }

        protected void tegjitha_CheckedChanged(object sender, EventArgs e)
        {
            if (tegjitha.Checked)
            {
                dropGrupNjesite.Enabled = false;
                dropGrupNjesite.Items.Clear();
            }
            else
            {
                merRegjione();
            }
            merNjesite();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.Items[0].Selected)
            {
                GjeneroGrafik1();
            }
            else
            {
                GjeneroGrafik2();
            }
        }

        private void GjeneroGrafik1()
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
            string selectedValueIndikatoret = dropIndikatoret.SelectedValue.ToString();

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
                //throw error ska njesi vendore te zgjedhura
                //ErrorLabel.Text = "Zgjidhni te pakten nje Njesi Vendore";
                return;
            }
            selectedValueNjesite = selectedValueNjesite.Substring(0, selectedValueNjesite.Length - 1);

            selectedValueVitet = selectedValueVitet.Substring(0, selectedValueVitet.Length - 1);

            //////////////////////

            lidhesi = new Requirenments();
            DataTable tedhenatPerGrafik = lidhesi.MerTeDhenat(selectedValueVitet, selectedValueNjesite, selectedValueIndikatoret).Copy();

            if (tedhenatPerGrafik.Rows.Count > 0)
            {
                string zevendesimi = "";


                string[] njesite = selectedValueNjesite.Split(',');
                string[] vitet = selectedValueVitet.Split(',');

                zevendesimi += "['Vitet',";
                for (int i = 0; i < njesite.Length; i++)
                {
                    DataTable emriNjesise = lidhesi.MerLGUSipasIndex(njesite[i]).Copy();
                    if (emriNjesise.Rows.Count > 0)
                    {
                        zevendesimi += "'" + emriNjesise.Rows[0].ItemArray[0].ToString() + "'";
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
                    DataTable emriVitet = lidhesi.MerVitinSipasIndex(vitet[j]).Copy();
                    if (emriVitet.Rows.Count > 0)
                    {
                        zevendesimi += "'" + emriVitet.Rows[0].ItemArray[0].ToString() + "'";
                    }
                    for (int k = 0; k < njesite.Length; k++)
                    {
                        int z = 0;
                        for (int m = 0; m < tedhenatPerGrafik.Rows.Count; m++)
                        {
                            if (tedhenatPerGrafik.Rows[m].ItemArray[1].ToString().Equals(vitet[j]) && tedhenatPerGrafik.Rows[m].ItemArray[2].ToString().Equals(njesite[k]))
                            {
                                zevendesimi += "," + tedhenatPerGrafik.Rows[m].ItemArray[4].ToString();
                                z++;
                            }
                        }
                        if (z == 0)
                        {
                            zevendesimi += ",0";
                        }
                    }



                    zevendesimi += "],";
                }

                zevendesimi = zevendesimi.Substring(0, zevendesimi.Length - 1);
                string s = File.ReadAllText(@"c:/data/a.txt");
                s = s.Replace("<%Title%>", "Ecuria ne Vitet e Zgjedhura ");
                grafiku.InnerHtml = s.Replace("<%data%>", zevendesimi);
            }
        }


        private void GjeneroGrafik2()
        {
            //ErrorLabel.Text = "";
            grafiku.InnerHtml = "";
            string selectedValueNjesite = "";
            foreach (ListItem item in chkNjesite.Items)
            {
                if (item.Selected)
                {
                    selectedValueNjesite += "'" + item.Text.ToString() + "',";
                }
            }
            if (selectedValueNjesite.Length == 0)
            {
                //throw error ska njesi vendore te zgjedhura
                //ErrorLabel.Text = "Zgjidhni te pakten nje Njesi Vendore";
                return;
            }
            //////////////////////
            string selectedValueIndikatoret = dropIndikatoret.SelectedValue.ToString();

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
                //throw error ska njesi vendore te zgjedhura
                //ErrorLabel.Text = "Zgjidhni te pakten nje Njesi Vendore";
                return;
            }
            selectedValueNjesite = selectedValueNjesite.Substring(0, selectedValueNjesite.Length - 1);

            selectedValueVitet = selectedValueVitet.Substring(0, selectedValueVitet.Length - 1);

            //////////////////////

            lidhesi = new Requirenments();
            DataTable tedhenatPerGrafik = lidhesi.MerTeDhenatByMunicipalityPeriudha(selectedValueVitet, selectedValueNjesite, selectedValueIndikatoret).Copy();

            if (tedhenatPerGrafik.Rows.Count > 0)
            {
                string zevendesimi = "";


                string[] njesite = selectedValueNjesite.Split(',');
                string[] vitet = selectedValueVitet.Split(',');

                zevendesimi += "['Vitet',";
                for (int i = 0; i < njesite.Length; i++)
                {

                    zevendesimi += njesite[i].ToString();

                    if (i < njesite.Length - 1)
                    {
                        zevendesimi += ",";
                    }
                }
                zevendesimi += "]," + Environment.NewLine;

                DataTable Mesataret = lidhesi.MerTeDhenatMesatareVitIndikator(selectedValueVitet, selectedValueIndikatoret).Copy();

                for (int j = 0; j < vitet.Length; j++)
                {
                    zevendesimi += "[";
                    DataTable emriVitet = lidhesi.MerVitinSipasIndex(vitet[j]).Copy();
                    if (emriVitet.Rows.Count > 0)
                    {
                        zevendesimi += "'" + emriVitet.Rows[0].ItemArray[0].ToString() + "'";
                    }
                    for (int k = 0; k < njesite.Length; k++)
                    {
                        int z = 0;
                        for (int m = 0; m < tedhenatPerGrafik.Rows.Count; m++)
                        {
                            if (tedhenatPerGrafik.Rows[m].ItemArray[1].ToString().Equals(vitet[j]) && tedhenatPerGrafik.Rows[m].ItemArray[0].ToString().Equals(njesite[k].Replace("'", "")))
                            {
                                zevendesimi += "," + tedhenatPerGrafik.Rows[m].ItemArray[2].ToString();
                                z++;
                            }
                        }
                        if (z == 0)
                        {
                            zevendesimi += ",0";
                        }
                    }



                    zevendesimi += "],";
                }

                zevendesimi = zevendesimi.Substring(0, zevendesimi.Length - 1);
                string s = File.ReadAllText(@"c:/data/a.txt");
                s = s.Replace("<%Title%>", "Ecuria ne Vitet e Zgjedhura ");

                grafiku.InnerHtml = s.Replace("<%data%>", zevendesimi);
            }
        }


        private void GjeneroGrafik3()
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
            string selectedValueIndikatoret = dropIndikatoret.SelectedValue.ToString();

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
                //throw error ska njesi vendore te zgjedhura
                //ErrorLabel.Text = "Zgjidhni te pakten nje Njesi Vendore";
                return;
            }
            selectedValueNjesite = selectedValueNjesite.Substring(0, selectedValueNjesite.Length - 1);

            selectedValueVitet = selectedValueVitet.Substring(0, selectedValueVitet.Length - 1);

            //////////////////////

            lidhesi = new Requirenments();
            DataTable tedhenatPerGrafik = lidhesi.MerTeDhenat(selectedValueVitet, selectedValueNjesite, selectedValueIndikatoret).Copy();

            if (tedhenatPerGrafik.Rows.Count > 0)
            {
                string zevendesimi = "";


                string[] njesite = selectedValueNjesite.Split(',');
                string[] vitet = selectedValueVitet.Split(',');

                zevendesimi += "['Vitet',";
                for (int i = 0; i < njesite.Length; i++)
                {
                    DataTable emriNjesise = lidhesi.MerLGUSipasIndex(njesite[i]).Copy();
                    if (emriNjesise.Rows.Count > 0)
                    {
                        zevendesimi += "'" + emriNjesise.Rows[0].ItemArray[0].ToString() + "'";
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
                    DataTable emriVitet = lidhesi.MerVitinSipasIndex(vitet[j]).Copy();
                    if (emriVitet.Rows.Count > 0)
                    {
                        zevendesimi += "'" + emriVitet.Rows[0].ItemArray[0].ToString() + "'";
                    }
                    for (int k = 0; k < njesite.Length; k++)
                    {
                        int z = 0;
                        for (int m = 0; m < tedhenatPerGrafik.Rows.Count; m++)
                        {
                            if (tedhenatPerGrafik.Rows[m].ItemArray[1].ToString().Equals(vitet[j]) && tedhenatPerGrafik.Rows[m].ItemArray[2].ToString().Equals(njesite[k]))
                            {
                                zevendesimi += "," + tedhenatPerGrafik.Rows[m].ItemArray[4].ToString();
                                z++;
                            }
                        }
                        if (z == 0)
                        {
                            zevendesimi += ",0";
                        }
                    }



                    zevendesimi += "],";
                }

                zevendesimi = zevendesimi.Substring(0, zevendesimi.Length - 1);
                string s = File.ReadAllText(@"c:/data/b.txt");
                s = s.Replace("<%Title%>", "Ecuria ne Vitet e Zgjedhura ");
                grafiku.InnerHtml = s.Replace("<%data%>", zevendesimi);
            }
        }

        private void GjeneroGrafik4()
        {
            //ErrorLabel.Text = "";
            grafiku.InnerHtml = "";
            string selectedValueNjesite = "";
            foreach (ListItem item in chkNjesite.Items)
            {
                if (item.Selected)
                {
                    selectedValueNjesite += "'" + item.Text.ToString() + "',";
                }
            }
            if (selectedValueNjesite.Length == 0)
            {
                //throw error ska njesi vendore te zgjedhura
                //ErrorLabel.Text = "Zgjidhni te pakten nje Njesi Vendore";
                return;
            }
            //////////////////////
            string selectedValueIndikatoret = dropIndikatoret.SelectedValue.ToString();

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
                //throw error ska njesi vendore te zgjedhura
                //ErrorLabel.Text = "Zgjidhni te pakten nje Njesi Vendore";
                return;
            }
            selectedValueNjesite = selectedValueNjesite.Substring(0, selectedValueNjesite.Length - 1);

            selectedValueVitet = selectedValueVitet.Substring(0, selectedValueVitet.Length - 1);

            //////////////////////

            lidhesi = new Requirenments();
            DataTable tedhenatPerGrafik = lidhesi.MerTeDhenatByMunicipalityPeriudha(selectedValueVitet, selectedValueNjesite, selectedValueIndikatoret).Copy();

            if (tedhenatPerGrafik.Rows.Count > 0)
            {
                string zevendesimi = "";


                string[] njesite = selectedValueNjesite.Split(',');
                string[] vitet = selectedValueVitet.Split(',');

                zevendesimi += "['Vitet',";
                for (int i = 0; i < njesite.Length; i++)
                {

                    zevendesimi += njesite[i].ToString();

                    if (i < njesite.Length - 1)
                    {
                        zevendesimi += ",";
                    }
                }
                zevendesimi += "]," + Environment.NewLine;

                DataTable Mesataret = lidhesi.MerTeDhenatMesatareVitIndikator(selectedValueVitet, selectedValueIndikatoret).Copy();

                for (int j = 0; j < vitet.Length; j++)
                {
                    zevendesimi += "[";
                    DataTable emriVitet = lidhesi.MerVitinSipasIndex(vitet[j]).Copy();
                    if (emriVitet.Rows.Count > 0)
                    {
                        zevendesimi += "'" + emriVitet.Rows[0].ItemArray[0].ToString() + "'";
                    }
                    for (int k = 0; k < njesite.Length; k++)
                    {
                        int z = 0;
                        for (int m = 0; m < tedhenatPerGrafik.Rows.Count; m++)
                        {
                            if (tedhenatPerGrafik.Rows[m].ItemArray[1].ToString().Equals(vitet[j]) && tedhenatPerGrafik.Rows[m].ItemArray[0].ToString().Equals(njesite[k].Replace("'", "")))
                            {
                                zevendesimi += "," + tedhenatPerGrafik.Rows[m].ItemArray[2].ToString();
                                z++;
                            }
                        }
                        if (z == 0)
                        {
                            zevendesimi += ",0";
                        }
                    }



                    zevendesimi += "],";
                }

                zevendesimi = zevendesimi.Substring(0, zevendesimi.Length - 1);
                string s = File.ReadAllText(@"c:/data/b.txt");
                s = s.Replace("<%Title%>", "Ecuria ne Vitet e Zgjedhura ");

                grafiku.InnerHtml = s.Replace("<%data%>", zevendesimi);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.Items[0].Selected)
            {
                GjeneroGrafik3();
            }
            else
            {
                GjeneroGrafik4();
            }
        }

        protected void dropGrupNjesite_SelectedIndexChanged(object sender, EventArgs e)
        {

            merNjesite();

        }

    }
}