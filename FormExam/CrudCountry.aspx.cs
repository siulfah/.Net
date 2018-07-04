using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormExam
{
    public partial class CrudCountry : System.Web.UI.Page
    {
        private worldEntities db = new worldEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        //protected void Button1_Click1(object sender, EventArgs e)
        //{
        //    if (buttonSave.Text == "Save") {
        //        Country country = new Country()
        //        {
        //            Country1 = countryNameInput.Text,
        //            Continent = ContinentInput.Text,
        //            Region_id = regionDropdown.SelectedIndex,
        //            Surface_Area = float.Parse(surfaceAreaInput.Text),
        //            Indep_Year = int.Parse(inYeInput.Text),
        //            Population = int.Parse(populationInput.Text)
        //        };

        //        db.Country.Add(country);
        //        db.SaveChanges();
        //        Response.Redirect("CrudCountry.aspx");
        //    }
        //    else
        //    {
        //        Country cy = db.Country.Find(int.Parse(GridView1.SelectedRow.Cells[0].Text));
        //        cy.Country1 = countryNameInput.Text;
        //        cy.Continent = ContinentInput.Text;
        //        cy.Region_id = regionDropdown.SelectedIndex;
        //        cy.Surface_Area = float.Parse(surfaceAreaInput.Text);
        //        cy.Indep_Year = int.Parse(inYeInput.Text);
        //        cy.Population = int.Parse(populationInput.Text);
        //        db.SaveChanges();
        //        Response.Redirect("CrudCountry.aspx");
        //    }

                
           
        //}

        protected void regionDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_OnRowDeleting(object sender, EventArgs e)
        {
            
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (buttonSave.Text == "Save")
            {
                Country country = new Country()
                {
                    Country1 = countryNameInput.Text,
                    Continent = ContinentInput.Text,
                    Region_id = int.Parse(regionDropdown.SelectedValue),
                    Surface_Area = float.Parse(surfaceAreaInput.Text),
                    Indep_Year = int.Parse(inYeInput.Text),
                    Population = int.Parse(populationInput.Text)
                };

                db.Country.Add(country);
                db.SaveChanges();
                Response.Redirect("CrudCountry.aspx");
            }
            else
            {
                Country cy = db.Country.Find(int.Parse(GridView2.SelectedRow.Cells[0].Text));
                cy.Country1 = countryNameInput.Text;
                cy.Continent = ContinentInput.Text;
                cy.Region_id = int.Parse(regionDropdown.SelectedValue);
                cy.Surface_Area = float.Parse(surfaceAreaInput.Text);
                cy.Indep_Year = int.Parse(inYeInput.Text);
                cy.Population = int.Parse(populationInput.Text);
                db.SaveChanges();
                Response.Redirect("CrudCountry.aspx");
            }
            
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            countryNameInput.Text = GridView2.SelectedRow.Cells[1].Text;
            ContinentInput.Text = GridView2.SelectedRow.Cells[2].Text;
            surfaceAreaInput.Text = GridView2.SelectedRow.Cells[4].Text;
            inYeInput.Text = GridView2.SelectedRow.Cells[5].Text;
            populationInput.Text = GridView2.SelectedRow.Cells[6].Text;
            buttonSave.Text = "Ubah";
        }
    }
}