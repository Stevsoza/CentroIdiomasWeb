using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capa_0_Web
{
    public partial class AdministracionEstudiantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarEstudiantes();
        }

        public void CargarEstudiantes()
        {
            DB_CentroIdiomasDataContext dataContext = new DB_CentroIdiomasDataContext();
            var consulta = from est in dataContext.ESTUDIANTES
                           select est;
            grdEstudiantes.DataSource = consulta;
            grdEstudiantes.DataBind();
        }
    }
}