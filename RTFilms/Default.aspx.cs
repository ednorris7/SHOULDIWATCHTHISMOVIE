using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Xml.Linq;
using Microsoft.Ajax.Utilities;

namespace BigMovies
{
    public partial class _Default : System.Web.UI.Page
    {
        public string analysis;

        protected void SearchDatabase(string searchCriteria)
        {
            Alg.Visible= true;
            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "SELECT * FROM Movies2 WHERE Movie LIKE @searchCriteria";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@searchCriteria", searchCriteria);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();


            GridView1.DataSource = reader;
            GridView1.DataBind();

            conn.Close();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchCriteria = txtSearch.Text;

            SearchDatabase(searchCriteria);
            
        }

        protected void alg_Click(object sender, EventArgs e)
        {
            string searchCriteria = txtSearch.Text;

            Analyse(searchCriteria);
        }

        protected void Analyse(string searchCriteria)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "SELECT [Critic Score] FROM Movies2 WHERE Movie LIKE @searchCriteria";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@searchCriteria", searchCriteria);
            conn.Open();

            object result = cmd.ExecuteScalar();
            int value = (int)result;
            conn.Close();

            string connnStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection connn = new SqlConnection(connnStr);
            string sqll = "SELECT [Audience Score] FROM Movies2 WHERE Movie LIKE @searchCriteria";
            SqlCommand cmmd = new SqlCommand(sqll, connn);
            cmmd.Parameters.AddWithValue("@searchCriteria", searchCriteria);
            connn.Open();

            object result2 = cmmd.ExecuteScalar();
            int value2 = (int)result2;
            connn.Close();

            int value3 = Math.Abs(value2 - value);


            if (value >= 90)
            {
                Alg1(value3);
            }
            else if (value >= 75)
            {
                Alg2(value3);
            }
            else if (value >= 60)
            {
                Alg3(value3);
            }
            else if (value >= 50)
            {
                Alg4(value3);
            }
            else
            {
                Alg5(value3);
            }

        }

        protected void Alg1(int value3)
        {
            if (value3 <= 5)
            {
                analysis = "This movie is going to be an absolute banger";
            }
            else if (value3 <= 10)
            {
                analysis = "This movie will be very good and you should definitely watch it";
            }
            else if (value3 <= 20)
            {
                analysis = "Movie should be pretty good";
            }
            else if (value3 <= 30)
            {
                analysis = "Critics like it and audience are less keen, movie may be leaning to a more artsy kinda thing";
            }
            else if (value3 > 30)
            {
                analysis = "This movie is either extremely artsy or it's been review bombed";
            }
        }

        protected void Alg2(int value3)
        {
            if (value3 <= 5)
            {
                analysis = "Very good movie that you probably should watch";
            }
            else if (value3 <= 10)
            {
                analysis = "An unbelievably mid movie or cult classic";
            }
            else if (value3 <= 20)
            {
                analysis = "The hardest movie to analyse. This could be the greatest movie of all time or it could the most boring movie of all time, it should be evident if you watch the trailer";
            }
            else if (value3 <= 30)
            {
                analysis = "TRUST ME THIS MOVIE IS AMAZING";
            }
            else if (value3 > 30)
            {
                analysis = "This movie is highly likely to terrible don't watch";
            }
        }

        protected void Alg3(int value3)
        {
            if (value3 <= 5)
            {
                analysis = "Average movie probably";
            }
            else if (value3 <= 10)
            {
                analysis = "Hard one to analyse, just watch it and if it sucks don't blame me";
            }
            else if (value3 <= 20)
            {
                analysis = "Masterpiece right here, watch it now";
            }
            else if (value3 <= 30)
            {
                analysis = "Masterpiece or dogshit. It should be evident which one after looking at the poster";
            }
            else if (value3 > 30)
            {
                analysis = "If you like fast and furious this shit gonna be fire";
            }
        }

        protected void Alg4(int value3)
        {
            if (value3 <= 5)
            {
                analysis = "Bad movie, don't watch";
            }
            else if (value3 <= 10)
            {
                analysis = "This movie definitley not good in any possible way";
            }
            else if (value3 <= 20)
            {
                analysis = "This movie might be good I say go for it, only saying that because Tron: Legacy falls here and thats in my top 5 movies ever lmao";
            }
            else if (value3 <= 30)
            {
                analysis = "Dumbass movie, could be good tho";
            }
            else if (value3 > 30)
            {
                analysis = "If the audience score is higher this movie is for sure alot of dumb fun";
            }
        }

        protected void Alg5(int value3)
        {
            if (value3 <= 5)
            {
                analysis = "Terrible movie";
            }
            else if (value3 <= 10)
            {
                analysis = "Awful movie";
            }
            else if (value3 <= 20)
            {
                analysis = "Most Likely an abhorrent viewing experience";
            }
            else if (value3 <= 30)
            {
                analysis = "Terrible or average, either don't watch";
            }
            else if (value3 > 30)
            {
                analysis = "Dumb box office movie that critics hate and audience love, if you like those kinda movies then go right ahead";
            }
        }
    }

}