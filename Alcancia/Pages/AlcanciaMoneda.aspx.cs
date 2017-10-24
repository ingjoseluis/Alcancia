using Alcancia.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Alcancia.Pages
{
    public partial class AlcanciaMoneda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!IsPostBack)
                {
                    var userId = Session["UserId"].ToString();

                    ddlDenominacion.DataSource = new Alcancia.Business.Denominacion().listDenominaciones();
                    ddlDenominacion.DataBind();

                    List<Alcancia_AlcMoneda> listAlcancia_AlcMoneda = new Alcancia.Business.AlcMoneda().List(userId);

                    foreach (Alcancia_AlcMoneda p in listAlcancia_AlcMoneda)
                    {
                        Alcancia_Denominacion alcancia_Denominacion = new Alcancia.Business.Denominacion().denominacionId(p.IdDenominacion);
                        p.IdDenominacion = alcancia_Denominacion.Denominacion;
                    }

                    GridView1.DataSource = listAlcancia_AlcMoneda;
                    GridView1.DataBind();

                    var query = from item in listAlcancia_AlcMoneda
                                group item by new { IdDenominacion = item.IdDenominacion } into g
                                select new
                                {
                                    IdDenominacion = g.Key.IdDenominacion,
                                    CantDenominacion = g.Sum(x => x.CantDenominacion),
                                    MontoDenominacion = (g.Key.IdDenominacion * g.Sum(x => x.CantDenominacion))
                                };

                    GridView2.DataSource = query.ToList();
                    GridView2.DataBind();

                    var querytotal = from item in query
                                     select new
                                     {
                                         CantMonedas = query.Sum(x => x.CantDenominacion),
                                         MontoMonedas = query.Sum(x => x.MontoDenominacion)
                                     };

                    Alcancia_AlcGeneral alcancia_AlcGeneral = new Alcancia.Business.AlcGeneral().totalAlcancia(userId);

                    Alcancia_AlcGeneral alc = new Alcancia_AlcGeneral();

                    if (alcancia_AlcGeneral.IdAlcGeneral.Equals(0))
                    {
                        alc.UserId = userId;
                        alc.CantMonedas = querytotal.FirstOrDefault().CantMonedas;
                        alc.MontoMonedas = querytotal.FirstOrDefault().MontoMonedas;

                        new Alcancia.Business.AlcGeneral().Insert(alc);
                    }
                    else
                    {
                        alc.IdAlcGeneral = alcancia_AlcGeneral.IdAlcGeneral;
                        alc.UserId = userId;
                        alc.CantMonedas = querytotal.FirstOrDefault().CantMonedas;
                        alc.MontoMonedas = querytotal.FirstOrDefault().MontoMonedas;

                        new Alcancia.Business.AlcGeneral().Update(alc);
                    }

                    GridView3.DataSource = querytotal.Distinct().ToList();
                    GridView3.DataBind();
                }
            }
            else
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "invocarfuncion", "alert('Usuario No Autenticado');window.location.href = '/Account/Login.aspx';", true);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCantDenominacion.Text.Equals(""))
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "invocarfuncion", "alert('Escriba la Cantidad de Moneda y seleccione Denominación Moneda');", true);
            else
            {
                Alcancia_AlcMoneda p = new Alcancia_AlcMoneda();

                p.UserId = Session["UserId"].ToString();
                p.IdDenominacion = int.Parse(ddlDenominacion.SelectedValue);
                p.CantDenominacion = int.Parse(txtCantDenominacion.Text);

                new Alcancia.Business.AlcMoneda().Insert(p);

                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "invocarfuncion", "alert('Ingreso Moneda Agregada');window.location.href = 'AlcanciaMoneda.aspx';", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtIdAlcMoneda.Text.Equals(""))
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "invocarfuncion", "alert('Escriba solo el Codigo Ingreso Moneda');", true);
            else
            {
                new Alcancia.Business.AlcMoneda().Delete(int.Parse(txtIdAlcMoneda.Text));

                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "invocarfuncion", "alert('Ingreso Moneda Eliminada');window.location.href = 'AlcanciaMoneda.aspx';", true);
            }
        }
    }
}