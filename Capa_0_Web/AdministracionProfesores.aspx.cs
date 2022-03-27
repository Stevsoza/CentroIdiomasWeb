using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capa_0_Web
{
    public partial class AdministracionProfesores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarProfesores();
        }

        public void CargarProfesores()
        {
            DB_CentroIdiomasDataContext dataContext = new DB_CentroIdiomasDataContext();
            var consulta = from prf in dataContext.PROFESORES
                           select prf;

            grdProfesores.DataSource = consulta;
            grdProfesores.DataBind();
        }
    }
}