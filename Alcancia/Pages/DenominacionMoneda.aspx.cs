using Alcancia.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Alcancia.Pages
{
    public partial class DenominacionMoneda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!IsPostBack)
                {
                    GridView1.DataSource = new Alcancia.Business.Denominacion().listDenominaciones();
                    GridView1.DataBind();
                }
            }
            else
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "invocarfuncion", "alert('Usuario No Autenticado');window.location.href = '/Account/Login.aspx';", true);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtDenominacionValor.Text.Equals(""))
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "invocarfuncion", "alert('Escriba la Denominación Moneda a Buscar');", true);
            else
            {
                Alcancia_Denominacion alcancia_Denominacion = new Alcancia.Business.Denominacion().denominacionValor(int.Parse(txtDenominacionValor.Text));

                if (!alcancia_Denominacion.IdDenominacion.Equals(0))
                {
                    txtIdDenominacion.Text = alcancia_Denominacion.IdDenominacion.ToString();
                    txtIdDenominacion.Enabled = false;
                    txtDenominacion.Text = alcancia_Denominacion.Denominacion.ToString();
                }
                else
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "invocarfuncion", "alert('Denominación Moneda no Existe');", true);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDenominacion.Text.Equals(""))
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "invocarfuncion", "alert('Escriba la Denominación Moneda');", true);
            else
            {
                Alcancia_Denominacion p = new Alcancia_Denominacion();

                Alcancia_Denominacion alcancia_Denominacion = new Alcancia.Business.Denominacion().denominacionValor(int.Parse(txtDenominacion.Text));

                if (alcancia_Denominacion.IdDenominacion.Equals(0))
                {
                    p.Denominacion = int.Parse(txtDenominacion.Text);

                    new Alcancia.Business.Denominacion().Insert(p);

                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "invocarfuncion", "alert('Denominación Moneda Agregada');window.location.href = 'DenominacionMoneda.aspx';", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "invocarfuncion", "alert('Denominación Moneda ya Existe');", true);
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtIdDenominacion.Text.Equals(""))
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "invocarfuncion", "alert('Escriba el Codigo Denominación y la Denominación Moneda');", true);
            else
            {
                Alcancia_Denominacion p = new Alcancia_Denominacion();

                p.IdDenominacion = int.Parse(txtIdDenominacion.Text);
                p.Denominacion = (txtDenominacion.Text.Equals("") ? 0 : int.Parse(txtDenominacion.Text));

                new Alcancia.Business.Denominacion().Update(p);

                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "invocarfuncion", "alert('Denominación Moneda Actualizada');window.location.href = 'DenominacionMoneda.aspx';", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtIdDenominacion.Text.Equals(""))
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "invocarfuncion", "alert('Escriba solo el Codigo Denominación');", true);
            else
            {
                new Alcancia.Business.Denominacion().Delete(int.Parse(txtIdDenominacion.Text));

                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "invocarfuncion", "alert('Denominación Moneda Eliminada');window.location.href = 'DenominacionMoneda.aspx';", true);
            }
        }
    }
}