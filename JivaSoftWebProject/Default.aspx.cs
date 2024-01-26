using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

namespace JivaSoftWebProject
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblErrorMessage.Text = "";
                BindGrid();
            }
            lblErrorMessage.Text = "";
        }

        private void BindGrid()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetWidgets", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();
                        sda.Fill(dt);
                        GridViewWidget.DataSource = dt;
                        GridViewWidget.DataBind();
                    }
                }
            }
        }

        protected void GridViewWidget_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            GridViewWidget.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridViewWidget_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int widgetID = (int)GridViewWidget.DataKeys[e.RowIndex].Value;
            string inventoryCode = (e.NewValues["InventoryCode"] != null) ? e.NewValues["InventoryCode"].ToString() : null;
            string description = (e.NewValues["Description"] != null) ? e.NewValues["Description"].ToString() : null;
            int quantityOnHand;
            int? reorderQuantity = null;
            int tempReorderQuantity = 0;

            if (string.IsNullOrWhiteSpace(inventoryCode))
            {
                ShowErrorMessage("Inventory Code is required.");
                return;
            }
            if (!int.TryParse(e.NewValues["QuantityOnHand"]?.ToString(), out quantityOnHand))
            {
                ShowErrorMessage("Quantity on Hand must be a valid integer.");
                return;
            }

            if (e.NewValues["ReorderQuantity"] != null && !int.TryParse(e.NewValues["ReorderQuantity"].ToString(), out  tempReorderQuantity))
            {
                ShowErrorMessage("Reorder Quantity must be a valid integer.");
                return;
            }
            else if (e.NewValues["ReorderQuantity"] != null)
            {
                reorderQuantity = tempReorderQuantity;
            }


            string connectionString = WebConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spUpdateWidget", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WidgetID", widgetID);
                    cmd.Parameters.AddWithValue("@InventoryCode", inventoryCode);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@QuantityOnHand", quantityOnHand);
                    cmd.Parameters.AddWithValue("@ReorderQuantity", reorderQuantity.HasValue ? (object)reorderQuantity : DBNull.Value);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridViewWidget.EditIndex = -1;
            BindGrid();
        }

        protected void GridViewWidget_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int widgetID = (int)GridViewWidget.DataKeys[e.RowIndex].Value;

            string connectionString = WebConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spDeleteWidget", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WidgetID", widgetID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            BindGrid();
        }

        protected void GridViewWidget_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            GridViewWidget.EditIndex = -1;
            BindGrid();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddWidget.aspx");
        }

        private void ShowErrorMessage(string message)
        {
            lblErrorMessage.Text = message;
        }
    }
}