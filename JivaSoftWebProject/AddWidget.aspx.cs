using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JivaSoftWebProject
{
    public partial class AddWidget : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtInventoryCode.Focus();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string inventoryCode = txtInventoryCode.Text;
            string description = txtDescription.Text;
            int quantityOnHand = int.Parse(txtQuantityOnHand.Text);
            int reorderQuantity = int.Parse(txtReorderQuantity.Text);

            string connectionString = WebConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spInsertWidget", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InventoryCode", inventoryCode);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@QuantityOnHand", quantityOnHand);
                    cmd.Parameters.AddWithValue("@ReorderQuantity", reorderQuantity);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            Response.Redirect("Default.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}