using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinancaVendore
{
    public partial class menaxhimifinanciaraspx : System.Web.UI.Page
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
                dropIndikatoret.DataSource = lidhesi.MerIndikatoretEGrupit("5").Copy();
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
    }
}