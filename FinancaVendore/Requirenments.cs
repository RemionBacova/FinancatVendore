using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace FinancaVendore
{
    public static class Req
    {
        public static Requirenments a = new Requirenments();
        static Req()
        {
            
        }
    }
    public class Requirenments
    {
        static Connection z = new Connection();
        DataTable b = new DataTable();
        // get

        public DataTable MerDistrict()
        {
            if( b != null) b.Clear();
            z.vektor = new string[0, 0];
            z.sp("MerDistrict", "tabela", ref b);
            return b;
        }

        public DataTable MerDistrictByRegion(string region)
        {
            if( b != null) b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "region";
            z.vektor[0, 1] = region;

            z.sp("MerDistrictByRegion", "tabela", ref b);
            return b;
        }



        public DataTable MerPeriudha()
        {
            if( b != null) b.Clear();
            z.vektor = new string[0, 0];
            z.sp("MerPeriudha", "tabela", ref b);
            return b;
        }

        public DataTable MerGrupIndikatore()
        {
            if( b != null) b.Clear();
            z.vektor = new string[0, 0];
            z.sp("MerGrupIndikatore", "tabela", ref b);
            return b;
        }

        public DataTable MerIndikatoretEGrupit(string groupId)
        {
            if( b != null) b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "groupId";
            z.vektor[0, 1] = groupId;
            z.sp("MerIndikatoretEGrupit", "tabela", ref b);
            return b;
        }

        public DataTable merLguByDistrict(string district)
        {
            if( b != null) b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "district";
            z.vektor[0, 1] = district;
            z.sp("merLguByDistrict", "tabela", ref b);
            return b;
        }

        public DataTable merLguByMunicipality(string municipality)
        {
            if( b != null) b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "municipality";
            z.vektor[0, 1] = municipality;
            z.sp("merLguByMunicipality", "tabela", ref b);
            return b;
        }

        public DataTable merLgu()
        {
            if (b != null) b.Clear();
            z.vektor = new string[0, 0];
            z.sp("merLgu", "tabela", ref b);
            return b;
        }


        public DataTable merLguByRegion(string region)
        {
            if( b != null) b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "region";
            z.vektor[0, 1] = region;
            z.sp("merLguByRegion", "tabela", ref b);
            return b;
        }

        public DataTable MerMunicipality()
        {
            if( b != null) b.Clear();
            z.vektor = new string[0, 0];
            z.sp("MerMunicipality", "tabela", ref b);
            return b;
        }


        public DataTable MerMunicipalityByRegion(string region)
        {
            if (b != null) b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "region";
            z.vektor[0, 1] = region;
            z.sp("MerMunicipalityByRegion", "tabela", ref b);
            return b;
        }




        public DataTable MerRegjione()
        {
            if( b != null) b.Clear();
            z.vektor = new string[0, 0];
            z.sp("MerRegjione", "tabela", ref b);
            return b;
        }


        public DataTable MerTeDhenatMesatareVitIndikator(string periodVar, string indicatorVar)
        {
            if (b != null) b.Clear();
            z.vektor = new string[2, 2];
            z.vektor[0, 0] = "periodVar";
            z.vektor[0, 1] = periodVar;
            z.vektor[1, 0] = "indicatorVar";
            z.vektor[1, 1] = indicatorVar;

            z.sp("MerTeDhenatMesatareVitIndikator", "tabela", ref b);
            return b;
        }


        public DataTable MerTeDhenatPerVitIndikator(string period_id, string indicator_id)
        {
            if (b != null) b.Clear();
            z.vektor = new string[2, 2];
            z.vektor[0, 0] = "period_id";
            z.vektor[0, 1] = period_id;
            z.vektor[1, 0] = "indicator_id";
            z.vektor[1, 1] = indicator_id;

            z.sp("MerTeDhenatPerVitIndikator", "tabela", ref b);
            return b;
        }

        public DataTable MerVitinSipasIndex(string nrrendor)
        {
            if (b != null) b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "nrrendor";
            z.vektor[0, 1] = nrrendor;


            z.sp("MerVitinSipasIndex", "tabela", ref b);
            return b;
        }


        public DataTable MerLGUSipasIndex(string nrrendor)
        {
            if (b != null) b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "nrrendor";
            z.vektor[0, 1] = nrrendor;


            z.sp("MerLGUSipasIndex", "tabela", ref b);
            return b;
        }


        public DataTable MerIndikatoretSipasIndex(string nrrendor)
        {
            if (b != null) b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "nrrendor";
            z.vektor[0, 1] = nrrendor;
        

            z.sp("MerIndikatoretSipasIndex", "tabela", ref b);
            return b;
        }


        public DataTable MerTeDhenatByMunicipalityPeriudha(string periodVar, string regionVar, string indicatorVar)
        {
            if( b != null) b.Clear();
            z.vektor = new string[3, 2];
            z.vektor[0, 0] = "periodVar";
            z.vektor[0, 1] = periodVar;
            z.vektor[1, 0] = "regionVar";
            z.vektor[1, 1] = regionVar;
            z.vektor[2, 0] = "indicatorVar";
            z.vektor[2, 1] = indicatorVar;
            z.sp("MerTeDhenatByMunicipalityPeriudha", "tabela", ref b);
            return b;
        }


        public DataTable MerTeDhenatGrupMunicipalityByPeriudha(string periodVar,  string indicatorVar)
        {
            if( b != null) b.Clear();
            z.vektor = new string[2, 2];
            z.vektor[0, 0] = "periodVar";
            z.vektor[0, 1] = periodVar;
            z.vektor[1, 0] = "indicatorVar";
            z.vektor[1, 1] = indicatorVar;
            z.sp("MerTeDhenatGrupMunicipalityByPeriudha", "tabela", ref b);
            return b;
        }

        public DataTable MerTeDhenatByMunicipality(string periodVar, string regionVar, string indicatorVar)
        {
            if( b != null) b.Clear();
            z.vektor = new string[3, 2];
            z.vektor[0, 0] = "periodVar";
            z.vektor[0, 1] = periodVar;
            z.vektor[1, 0] = "regionVar";
            z.vektor[1, 1] = regionVar;
            z.vektor[2, 0] = "indicatorVar";
            z.vektor[2, 1] = indicatorVar;
            z.sp("MerTeDhenatByMunicipality", "tabela", ref b);
            return b;
        }
        public DataTable MerTeDhenat(string periodVar, string regionVar, string indicatorVar)
        {
            if( b != null) b.Clear();
            z.vektor = new string[3, 2];
            z.vektor[0, 0] = "periodVar";
            z.vektor[0, 1] = periodVar;
            z.vektor[1, 0] = "regionVar";
            z.vektor[1, 1] = regionVar;
            z.vektor[2, 0] = "indicatorVar";
            z.vektor[2, 1] = indicatorVar;
            z.sp("MerTeDhenat", "tabela", ref b);
            return b;
        }


        /// <summary>
        /// To Delete a row from database
        /// </summary>
        /// <param name="TABLE">Table name ex:[tbl_users]</param>
        /// <param name="UID">The Unique Id if row to be deleted</param>
        //public void DeleteRow(string TABLE, string UID)
        //{
        //    z.vektor = new string[2, 2];
        //    z.vektor[0, 0] = "TABLE";
        //    z.vektor[0, 1] = TABLE;
        //    z.vektor[1, 0] = "UID";
        //    z.vektor[1, 1] = UID;
        //    z.ip("DeleteRow");
        //}

        //
    
        //public void spU_tbl_info(string UID, string UID_SUP, string ELEMENT_UID, string TYPE_INFO_UID, string NOMINATION, string DESCRIPTION, string DESCRIPTION2, string DESCRIPTION3, string USER_UID, string tabela)
        //{
        //    z.vektor = new string[9, 2];
        //    z.vektor[0, 0] = "UID";
        //    z.vektor[0, 1] = UID;
        //    z.vektor[1, 0] = "UID_SUP";
        //    z.vektor[1, 1] = UID_SUP;
        //    z.vektor[2, 0] = "ELEMENT_UID";
        //    z.vektor[2, 1] = ELEMENT_UID;
        //    z.vektor[3, 0] = "TYPE_INFO_UID";
        //    z.vektor[3, 1] = TYPE_INFO_UID;
        //    z.vektor[4, 0] = "NOMINATION";
        //    z.vektor[4, 1] = NOMINATION;
        //    z.vektor[5, 0] = "DESCRIPTION";
        //    z.vektor[5, 1] = DESCRIPTION;
        //    z.vektor[6, 0] = "DESCRIPTION2";
        //    z.vektor[6, 1] = DESCRIPTION2;
        //    z.vektor[7, 0] = "DESCRIPTION3";
        //    z.vektor[7, 1] = DESCRIPTION3;
        //    z.vektor[8, 0] = "USER_UID";
        //    z.vektor[8, 1] = USER_UID;
        //    z.ip("spU_" + tabela);
        //}
    }
}