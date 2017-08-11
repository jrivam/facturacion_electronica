using Facel.Business.Entities;
using Facel.Business.Logics;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace App_ifac
{
    public partial class mEmpresa : System.Web.UI.Page
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

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        protected void Buscar()
        {
            grvEmpresas.DataSource = new Empresa_BL().GetDataTable(new Empresa_BE());
            grvEmpresas.DataBind();
        }
        protected void Cargar(int id)
        {
            Empresa_BE be = new Empresa_BE();

            be.Id = id;
            new Empresa_BL().Load(be);

            txtRuc.Text = be.Ruc;
            txtRazonSocial.Text = be.RazonSocial;
            txtDireccionFiscal.Text = be.DireccionFiscal;
            txtTelefono.Text = be.Telefono;
            txtEmail.Text = be.Email;
            txtPaginaWeb.Text = be.Website;
            txtUsuarioSunat.Text = be.UsuarioSunat;
            txtClaveSunat.Text = be.ClaveSunat;
            txtEmailEnvio.Text = be.EmailEnvio;
            txtClaveEmail.Text = be.ClaveEmail;
            txtSmtpEmail.Text = be.SmtpEmail;
            txtPuertoEmail.Text = be.PuertoEmail.ToString();

            ((HtmlInputCheckBox)Page.Form.FindControl("mainBody").FindControl("chkActivo")).Checked = be.Activo ?? be.Activo.Value;
            ((HtmlInputCheckBox)Page.Form.FindControl("mainBody").FindControl("chkElectronico")).Checked = be.EsEmisorElectronico ?? be.EsEmisorElectronico.Value;
            ((HtmlInputCheckBox)Page.Form.FindControl("mainBody").FindControl("chkSSL")).Checked = be.EsSsl ?? be.EsSsl.Value;
            ((HtmlInputCheckBox)Page.Form.FindControl("mainBody").FindControl("chkCorporativo")).Checked = be.EsCorporativo ?? be.EsCorporativo.Value;
            ((HtmlInputCheckBox)Page.Form.FindControl("mainBody").FindControl("chkAgentePercepcion")).Checked = be.EsAgentePercepcion ?? be.EsAgentePercepcion.Value;
            ((HtmlInputCheckBox)Page.Form.FindControl("mainBody").FindControl("chkAgenteRetencion")).Checked = be.EsAgenteRetencion ?? be.EsAgenteRetencion.Value;
            ((HtmlInputCheckBox)Page.Form.FindControl("mainBody").FindControl("chkBuenContribuyente")).Checked = be.EsBuenContribuyente ?? be.EsBuenContribuyente.Value;

            ((HtmlInputRadioButton)Page.Form.FindControl("mainBody").FindControl("rbtPruebas")).Checked = be.EnPruebas ?? be.EnPruebas.Value;
            ((HtmlInputRadioButton)Page.Form.FindControl("mainBody").FindControl("rbtHomologacion")).Checked = be.Homologado ?? be.Homologado.Value;
            ((HtmlInputRadioButton)Page.Form.FindControl("mainBody").FindControl("rbtProduccion")).Checked = be.EnProduccion ?? be.EnProduccion.Value;
        }
        protected void Grabar()
        {
            Empresa_BE be = new Empresa_BE();

            var id = Request.QueryString["id"];
            if (id != null)
            {
                be.Id = Convert.ToInt16(id.ToString());
                new Empresa_BL().Load(be);
            }

            be.Ruc = txtRuc.Text;
            be.RazonSocial = txtRazonSocial.Text;
            be.DireccionFiscal = txtDireccionFiscal.Text;
            be.Direccion = be.DireccionFiscal;
            be.Telefono = txtTelefono.Text;
            be.Email = txtEmail.Text;
            be.Website = txtPaginaWeb.Text;
            be.UsuarioSunat = txtUsuarioSunat.Text;
            be.ClaveSunat = txtClaveSunat.Text;
            be.EmailEnvio = txtEmailEnvio.Text;
            be.ClaveEmail = txtClaveEmail.Text;
            be.SmtpEmail = txtSmtpEmail.Text;
            be.PuertoEmail = Convert.ToInt16(txtPuertoEmail.Text);

            be.Activo = ((HtmlInputCheckBox)Page.Form.FindControl("mainBody").FindControl("chkActivo")).Checked;
            be.EsEmisorElectronico = ((HtmlInputCheckBox)Page.Form.FindControl("mainBody").FindControl("chkElectronico")).Checked;
            be.EsSsl = ((HtmlInputCheckBox)Page.Form.FindControl("mainBody").FindControl("chkSSL")).Checked;
            be.EsCorporativo = ((HtmlInputCheckBox)Page.Form.FindControl("mainBody").FindControl("chkCorporativo")).Checked;
            be.EsAgentePercepcion = ((HtmlInputCheckBox)Page.Form.FindControl("mainBody").FindControl("chkAgentePercepcion")).Checked;
            be.EsAgenteRetencion = ((HtmlInputCheckBox)Page.Form.FindControl("mainBody").FindControl("chkAgenteRetencion")).Checked;
            be.EsBuenContribuyente = ((HtmlInputCheckBox)Page.Form.FindControl("mainBody").FindControl("chkBuenContribuyente")).Checked;

            be.EnPruebas = ((HtmlInputRadioButton)Page.Form.FindControl("mainBody").FindControl("rbtPruebas")).Checked;
            be.Homologado = ((HtmlInputRadioButton)Page.Form.FindControl("mainBody").FindControl("rbtHomologacion")).Checked;
            be.EnProduccion = ((HtmlInputRadioButton)Page.Form.FindControl("mainBody").FindControl("rbtProduccion")).Checked;

            new Empresa_BL().Save(be);
        }
    }
}