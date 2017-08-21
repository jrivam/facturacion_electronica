using Facel.Business.Entities;
using Facel.Business.Logics;
using System;
using System.Transactions;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace App_ifac
{
    public partial class mSucursal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;

            cboEmpresa.DataSource = new Empresa_BL().GetDataCombo(new Empresa_BE(), "empresa_id", "empresa_razon_social");
            cboEmpresa.DataBind();

            var id = Request.QueryString["id"];

            if (id != null)
            {
                Cargar(Convert.ToInt16(id.ToString()));
            }

            Buscar();
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Grabar();
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
            txtTelefono.Text = be.Telefono;

            ((HtmlInputCheckBox)Page.Form.FindControl("mainBody").FindControl("chkEsPrincipal")).Checked = be.EsPrincipal ?? be.EsPrincipal.Value;

            ((HtmlInputCheckBox)Page.Form.FindControl("mainBody").FindControl("chkActivo")).Checked = be.Activo ?? be.Activo.Value;
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

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    if (new Sucursal_BL().Save(be, Library.Framework.Layers.SaveStatus.Complete) == 1)
                    {
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            
        }
    }
}