using Facel.Business.Entities;
using Facel.Business.Logics;
using System;
using System.Web.UI;

namespace App_ifac
{
    public partial class mSucursal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;

            var id = Request.QueryString["id"];

            if (id != null)
            {
                Cargar(Convert.ToInt16(id.ToString()));
            }

            Buscar();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        protected void Buscar()
        {
            grvSucursales.DataSource = new Sucursal_BL().GetDataTable(new Sucursal_BE());
            grvSucursales.DataBind();
        }
        protected void Cargar(int id)
        {
            Sucursal_BE be = new Sucursal_BE();

            be.Id = id;
            new Sucursal_BL().Load(be);

            txtNombreSucursal.Text = be.Nombre;
            txtDireccionSucursal.Text = be.Direccion;
        }
        protected void Grabar()
        {
            Sucursal_BE be = new Sucursal_BE();

            var id = Request.QueryString["id"];
            if (id != null)
            {
                be.Id = Convert.ToInt16(id.ToString());
                new Sucursal_BL().Load(be);
            }

            be.Nombre = txtNombreSucursal.Text;
            be.Direccion = txtDireccionSucursal.Text;

            new Sucursal_BL().Save(be);
        }
    }
}