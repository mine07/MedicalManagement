using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MedicalManagement.Models;
using MedicalManagement.Models.DTO;

namespace MedicalManagement
{
    public partial class Consulta : System.Web.UI.MasterPage
    {
        public int Id_Agenda = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Agenda"]);
        public int Id_FichaIdentificacion = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_FichaIdentificacion"]);
        public string NombreCompleto = Convert.ToString(System.Web.HttpContext.Current.Request.QueryString["NombreCompleto"]);
        int Id_Consulta = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Consulta"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            if (!IsPostBack)
            {
                
                if (Id_FichaIdentificacion != 0)
                {
                    loadUsuario();
                    lblNombre.Text = NombreCompleto;
                    GridViewActivos();
                    GridViewInactivos();
                    GridViewFechaConsulta();
                    llenartxtantecedentesnotas();
                    GridViewProcedimiento();
                    SqlConnection cnn;
                    cnn = new SqlConnection(conexion);
                    cnn.Open();
                    string consulta = "select Id_Consulta from Tabla_Registro_Consulta where Id_Agenda=" + Id_Agenda +
                                      "";
                    SqlCommand comando = new SqlCommand(consulta, cnn);
                    Id_Consulta = Convert.ToInt32(comando.ExecuteScalar());
                    Session["Id_Consultas"] = Id_Consulta;
                    loadFile(new Tabla_Catalogo_FichaIdentificacionDTO { Id_FichaIdentificacion = Id_FichaIdentificacion });
                    if (Id_Consulta != 0)
                    {
                        LinkReceta.Visible = true;
                    }
                }
            }
        }

        /////////////LINKS DEL MENU CONSULTAS/////////////////////////////////////////////////////////////////////

        protected void LinkNotaClinica_Click(object sender, EventArgs e)
        {
            loadUsuario();
            Response.Redirect("RegistroConsulta.aspx?Id_Agenda=" + Id_Agenda + " &Id_FichaIdentificacion=" + Id_FichaIdentificacion + "&NombreCompleto=" + NombreCompleto + "");
        }

        protected void LinkReceta_Click(object sender, EventArgs e)
        {
            loadUsuario();
            Id_Consulta = Convert.ToInt32(Session["Id_Consultas"]);
            Response.Redirect("ConsultaReceta.aspx?Id_Agenda=" + Id_Agenda + " &Id_FichaIdentificacion=" + Id_FichaIdentificacion + "&NombreCompleto=" + NombreCompleto + "&Id_Consulta=" + Id_Consulta + "");
        }

        protected void LinkAnalisisClinico_Click(object sender, EventArgs e)
        {
            loadUsuario();
            Id_Consulta = Convert.ToInt32(Session["Id_Consultas"]);
            Response.Redirect("ConsultaAnalisisClinico.aspx?Id_Agenda=" + Id_Agenda + " &Id_FichaIdentificacion=" + Id_FichaIdentificacion + "&NombreCompleto=" + NombreCompleto + "&Id_Consulta=" + Id_Consulta + "");
        }


        ////////////CHECKBOXS DEL MENU CONSULTAS///////////////////////////////////////////
        protected void CheckBoxactivo_CheckedChanged(object sender, EventArgs e)
        {
            //int numeroidperfil = Convert.ToInt32(ddl_Id_Perfil.SelectedValue);
            CheckBox chseleccionado;

            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();

            foreach (GridViewRow row in GridViewDiagnosticosActivos.Rows)
            {

                int valorIddiagnostico = Convert.ToInt32(row.Cells[0].Text);


                int varlorcheck = 0;
                chseleccionado = row.FindControl("CheckBoxelegir") as CheckBox;
                if (chseleccionado.Checked == true)
                {
                    varlorcheck = 1;
                }
                else
                {
                    varlorcheck = 0;
                }

                SqlCommand comando = new SqlCommand(@"update Tabla_Registro_ConsultaDiagnostico set Estatus_ConsultaDiagnostico=" + varlorcheck + @"
                                                      where Id_FichaIdentificacion=" + Id_FichaIdentificacion + " and Id_Diagnostico=" + valorIddiagnostico + "", cnn);


                //comando.CommandType = CommandType.StoredProcedure;

                //comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                //comando.Parameters.AddWithValue("@Id_Perfil", numeroidperfil);
                //comando.Parameters.AddWithValue("@Id_Modulo", numeroidmodulo);
                //comando.Parameters.AddWithValue("@Estatus_Permiso", varlorcheck);

                comando.ExecuteNonQuery();


            }

            foreach (GridViewRow row in GridViewDiagnosticosInactivos.Rows)
            {

                int valorIddiagnostico = Convert.ToInt32(row.Cells[0].Text);


                int varlorcheck = 0;
                chseleccionado = row.FindControl("CheckBoxelegir") as CheckBox;
                if (chseleccionado.Checked == true)
                {
                    varlorcheck = 1;
                }
                else
                {
                    varlorcheck = 0;
                }

                SqlCommand comando = new SqlCommand(@"update Tabla_Registro_ConsultaDiagnostico set Estatus_ConsultaDiagnostico=" + varlorcheck + @"
                                                      where Id_FichaIdentificacion=" + Id_FichaIdentificacion + " and Id_Diagnostico=" + valorIddiagnostico + "", cnn);
                //comando.CommandType = CommandType.StoredProcedure;


                //comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                //comando.Parameters.AddWithValue("@Id_Perfil", numeroidperfil);
                //comando.Parameters.AddWithValue("@Id_Modulo", numeroidmodulo);
                //comando.Parameters.AddWithValue("@Estatus_Permiso", varlorcheck);

                comando.ExecuteNonQuery();


            }
            cnn.Close();
            System.Web.HttpContext.Current.Response.Write("<script>javascript: alert('Datos modificados');</script>");
            GridViewActivos();
            GridViewInactivos();

        }

        protected void CheckBoxinactivo_CheckedChanged(object sender, EventArgs e)
        {
            //int numeroidperfil = Convert.ToInt32(ddl_Id_Perfil.SelectedValue);
            CheckBox chseleccionado;

            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();

            foreach (GridViewRow row in GridViewDiagnosticosActivos.Rows)
            {

                int valorIddiagnostico = Convert.ToInt32(row.Cells[0].Text);


                int varlorcheck = 0;
                chseleccionado = row.FindControl("CheckBoxelegir") as CheckBox;
                if (chseleccionado.Checked == true)
                {
                    varlorcheck = 1;
                }
                else
                {
                    varlorcheck = 0;
                }

                SqlCommand comando = new SqlCommand(@"update Tabla_Registro_ConsultaDiagnostico set Estatus_ConsultaDiagnostico=" + varlorcheck + @"
                                                      where Id_FichaIdentificacion=" + Id_FichaIdentificacion + " and Id_Diagnostico=" + valorIddiagnostico + "", cnn);


                //comando.CommandType = CommandType.StoredProcedure;

                //comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                //comando.Parameters.AddWithValue("@Id_Perfil", numeroidperfil);
                //comando.Parameters.AddWithValue("@Id_Modulo", numeroidmodulo);
                //comando.Parameters.AddWithValue("@Estatus_Permiso", varlorcheck);

                comando.ExecuteNonQuery();


            }

            foreach (GridViewRow row in GridViewDiagnosticosInactivos.Rows)
            {

                int valorIddiagnostico = Convert.ToInt32(row.Cells[0].Text);


                int varlorcheck = 0;
                chseleccionado = row.FindControl("CheckBoxelegir") as CheckBox;
                if (chseleccionado.Checked == true)
                {
                    varlorcheck = 1;
                }
                else
                {
                    varlorcheck = 0;
                }

                SqlCommand comando = new SqlCommand(@"update Tabla_Registro_ConsultaDiagnostico set Estatus_ConsultaDiagnostico=" + varlorcheck + @"
                                                      where Id_FichaIdentificacion=" + Id_FichaIdentificacion + " and Id_Diagnostico=" + valorIddiagnostico + "", cnn);
                //comando.CommandType = CommandType.StoredProcedure;


                //comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                //comando.Parameters.AddWithValue("@Id_Perfil", numeroidperfil);
                //comando.Parameters.AddWithValue("@Id_Modulo", numeroidmodulo);
                //comando.Parameters.AddWithValue("@Estatus_Permiso", varlorcheck);

                comando.ExecuteNonQuery();


            }
            cnn.Close();
            System.Web.HttpContext.Current.Response.Write("<script>javascript: alert('Datos modificados');</script>");
            GridViewActivos();
            GridViewInactivos();

        }
        //////////////////////////////////////////////////////////////////////////////////


        private List<ConsultaDiagnosticoDTO> loadDiagnosticos()
        {
            var oneConsultadia = new ConsultaDiagnosticoDTO();
            oneConsultadia.Id_FichaIdentificacion = Id_FichaIdentificacion;
            return ConsultaDiagnosticoDAO.GetAllByPaciente(oneConsultadia).Where(x => x.Id_Consulta == Id_Agenda).ToList();
        }

        private List<ConsultaProcedimientoDTO> loadProcedimiento(NotaClinicaDTO oneNota)
        {
            var oneConsultapro = new ConsultaProcedimientoDTO();
            oneConsultapro.Id_FichaIdentificacion = Id_FichaIdentificacion;
            return ConsultaProcedimientoDAO.GetAllByPaciente(oneConsultapro).Where(x => x.Id_Consulta == oneNota.Id_Agenda).ToList();
        }

        //        public void GridViewActivos()
        //        {
        //            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

        //            SqlConnection cnn;
        //            cnn = new SqlConnection(conexion);

        //            cnn.Open();

        //            string sentencia1 = "select Id_Consulta from Tabla_Registro_Consulta where Id_FichaIdentificacion="+Id_FichaIdentificacion+"";
        //            SqlCommand comando1 = new SqlCommand(sentencia1, cnn);
        //            SqlDataAdapter da1= new SqlDataAdapter(comando1);
        //            DataTable ds1 = new DataTable();
        //            da1.Fill(ds1);
        //            int sentenciaIdConsulta=0;

        //            string sentencia="";
        //            //SqlCommand comando = new SqlCommand(sentencia, cnn);
        //            //SqlDataAdapter da = new SqlDataAdapter(comando);
        //            DataTable ds = new DataTable();
        //            DataRow row1;
        //            row1 = ds.NewRow();
        //            DataColumn column;
        //            column = new DataColumn();
        //            column.DataType = System.Type.GetType("System.Int32");
        //            column.ColumnName = "id";
        //            ds.Columns.Add(column);
        //            SqlDataReader reader;

        //            foreach (DataRow row in ds1.Rows)
        //            {

        //                sentenciaIdConsulta = Convert.ToInt32(row["Id_Consulta"]);

        //                sentencia = @"select a.Id_AnalisisClinico, b.Descripcion_AnalisisClinico,a.Estatus_ConsultaAnalisisClinico,c.Fecha_Consulta from Tabla_Registro_ConsultaAnalisisClinico a join Tabla_Catalogo_AnalisisClinico b                               
        //                               on a.Id_AnalisisClinico=b.Id_AnalisisClinico
        //                               join Tabla_Registro_Consulta c
        //                               on a.Id_FichaIdentificacion= c.Id_FichaIdentificacion
        //                               where a.Id_FichaIdentificacion=" + Id_FichaIdentificacion + "and Estatus_ConsultaAnalisisClinico=1 and c.Id_Consulta=" + sentenciaIdConsulta + "";

        //                int a=0 ;
        //                string b="";  
        //                string c="" ;
        //                DateTime c1;

        //                SqlCommand comando = new SqlCommand(sentencia, cnn);
        //                comando.CommandType = CommandType.Text;
        //                SqlDataAdapter da = new SqlDataAdapter(comando);

        //                //reader = comando.ExecuteReader();
        //                //if (reader.Read())
        //                //{
        //                //    a = reader.GetInt32(reader.GetOrdinal("Id_AnalisisClinico"));
        //                //    b = reader.GetString(reader.GetOrdinal("Descripcion_AnalisisClinico")).Trim();
        //                //    c = reader.GetDateTime(reader.GetOrdinal("Fecha_Consulta")).ToShortDateString();
        //                //    c1 = Convert.ToDateTime(c);                    

        //                //}

        //                //row1["Id_AnalisisClinico"] = a;
        //                //row1["Descripcion_AnalisisClinico"] = b;
        //                //row1["Fecha_Consulta"] = c;
        //                //row1 = row;
        //                da.Fill(ds);
        //                //ds.Rows.Add(row1);
        //                //reader.Close();
        //                comando = null;
        //            }


        //            //da.Fill(ds);


        //            GridViewDiagnosticosActivos.Visible = true;
        //            GridViewDiagnosticosActivos.DataSource = ds;

        //            GridViewDiagnosticosActivos.Columns[0].Visible = true;
        //            GridViewDiagnosticosActivos.Columns[2].Visible = true;
        //            GridViewDiagnosticosActivos.DataBind();

        //            CheckBox chseleccionado;

        //            foreach (GridViewRow row in GridViewDiagnosticosActivos.Rows)
        //            {
        //                bool valorcheck = false;
        //                valorcheck = Convert.ToBoolean(row.Cells[2].Text);
        //                chseleccionado = row.FindControl("CheckBoxelegir") as CheckBox;
        //                if (valorcheck == true)
        //                {
        //                    chseleccionado.Checked = true;

        //                }
        //                else
        //                {
        //                    chseleccionado.Checked = false;
        //                }
        //            }

        //            GridViewDiagnosticosActivos.Columns[0].Visible = false;
        //            GridViewDiagnosticosActivos.Columns[2].Visible = false;
        //            ds.Dispose();
        //            //da.Dispose();
        //            cnn.Close();
        //        }



        ////////////GRIDS DEL MENU CONSULTAS///////////////////////////////////////////

        public void GridViewActivos()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();


            string sentencia = @"select a.Id_Diagnostico, a.Id_ConsultaDiagnostico, b.Descripcion_Diagnostico,a.Fecha_ConsultaDiagnostico,a.Estatus_ConsultaDiagnostico from Tabla_Registro_ConsultaDiagnostico a join Tabla_Catalogo_Diagnostico b 
                               on a.Id_Diagnostico=b.Id_Diagnostico
                               where a.Id_FichaIdentificacion=" + Id_FichaIdentificacion + "and Estatus_ConsultaDiagnostico=1 order by a.Fecha_ConsultaDiagnostico desc";

            SqlCommand comando = new SqlCommand(sentencia, cnn);

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            GridViewDiagnosticosActivos.Visible = true;
            GridViewDiagnosticosActivos.DataSource = ds;
            rptActivos.DataSource = ds;
            rptActivos.DataBind();
            GridViewDiagnosticosActivos.Columns[0].Visible = true;
            GridViewDiagnosticosActivos.Columns[2].Visible = true;
            GridViewDiagnosticosActivos.DataBind();

            CheckBox chseleccionado;

            foreach (GridViewRow row in GridViewDiagnosticosActivos.Rows)///////////"GridViewDiagnosticosActivos"
            {
                bool valorcheck = false;
                valorcheck = Convert.ToBoolean(row.Cells[2].Text);
                chseleccionado = row.FindControl("CheckBoxelegir") as CheckBox;
                if (valorcheck == true)
                {
                    chseleccionado.Checked = true;

                }
                else
                {
                    chseleccionado.Checked = false;
                }
            }

            GridViewDiagnosticosActivos.Columns[0].Visible = false;
            GridViewDiagnosticosActivos.Columns[2].Visible = false;
            ds.Dispose();
            da.Dispose();
            cnn.Close();
        }



        public void GridViewInactivos()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();

            string sentencia = @"select a.Id_Diagnostico,a.Id_ConsultaDiagnostico, b.Descripcion_Diagnostico,a.Fecha_ConsultaDiagnostico,a.Estatus_ConsultaDiagnostico from Tabla_Registro_ConsultaDiagnostico a join Tabla_Catalogo_Diagnostico b 
                               on a.Id_Diagnostico=b.Id_Diagnostico
                               where a.Id_FichaIdentificacion=" + Id_FichaIdentificacion + "and Estatus_ConsultaDiagnostico=0 order by a.Fecha_ConsultaDiagnostico desc";

            SqlCommand comando = new SqlCommand(sentencia, cnn);

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            GridViewDiagnosticosInactivos.Visible = true;
            GridViewDiagnosticosInactivos.DataSource = ds;
            rptInactivos.DataSource = ds;
            rptInactivos.DataBind();
            GridViewDiagnosticosInactivos.Columns[0].Visible = true;
            GridViewDiagnosticosInactivos.Columns[2].Visible = true;
            GridViewDiagnosticosInactivos.DataBind();

            CheckBox chseleccionado;

            foreach (GridViewRow row in GridViewDiagnosticosActivos.Rows)///////////"GridViewDiagnosticosActivos"
            {
                bool valorcheck = false;
                valorcheck = Convert.ToBoolean(row.Cells[2].Text);
                chseleccionado = row.FindControl("CheckBoxelegir") as CheckBox;
                if (valorcheck == true)
                {
                    chseleccionado.Checked = true;

                }
                else
                {
                    chseleccionado.Checked = false;
                }
            }

            GridViewDiagnosticosInactivos.Columns[0].Visible = false;
            GridViewDiagnosticosInactivos.Columns[2].Visible = false;
            ds.Dispose();
            da.Dispose();
            cnn.Close();
        }

        public void GridViewProcedimiento()
        {

            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();

            string sentencia = @"select a.Id_Procedimiento, b.Descripcion_Procedimiento,a.Fecha_ConsultaProcedimiento,a.Estatus_ConsultaProcedimiento from Tabla_Registro_ConsultaProcedimiento a join Tabla_Catalogo_Procedimiento b 
                               on a.Id_Procedimiento=b.Id_Procedimiento
                               where a.Id_FichaIdentificacion=" + Id_FichaIdentificacion + "and Estatus_ConsultaProcedimiento=1 order by a.Fecha_ConsultaProcedimiento desc";

            SqlCommand comando = new SqlCommand(sentencia, cnn);

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            GridViewProcedimientos.Visible = true;
            GridViewProcedimientos.DataSource = ds;

            GridViewProcedimientos.Columns[0].Visible = true;

            GridViewProcedimientos.DataBind();

            GridViewProcedimientos.Columns[0].Visible = false;
            rptProcedimientos.DataSource = ds;
            rptProcedimientos.DataBind();
            ds.Dispose();
            da.Dispose();
            cnn.Close();
        }

        public void GridViewFechaConsulta()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();

            string sentencia = @"select Id_Consulta,Fecha_Consulta from Tabla_Registro_Consulta
                               where Id_FichaIdentificacion=" + Id_FichaIdentificacion + "";

            SqlCommand comando = new SqlCommand(sentencia, cnn);

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            GridViewFecha.Visible = true;
            GridViewFecha.DataSource = ds;

            GridViewFecha.Columns[0].Visible = true;

            GridViewFecha.DataBind();

            GridViewFecha.Columns[0].Visible = false;

            ds.Dispose();
            da.Dispose();
            cnn.Close();

        }

        /////////////////////////////////////////////////////////////////////

        protected void llenartxtantecedentesnotas()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();
            SqlCommand comando = new SqlCommand("SP_Registro_ConsultasAntecedentesNotas", cnn);
            comando.Parameters.AddWithValue("@Opcion", "ENCONTRAR");
            comando.Parameters.AddWithValue("@Id_FichaIdentificacion", Id_FichaIdentificacion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                txtantecedentes.Text = reader.GetString(reader.GetOrdinal("Antecedentes_Relevantes")).ToString();
                txtnotasrelevantes.Text = reader.GetString(reader.GetOrdinal("Notas_Relevantes")).ToString();
            }

            reader.Close();
            comando = null;
            cnn.Close();

        }

        public void loadUsuario()
        {
            string query = "select * from Tabla_Catalogo_FichaIdentificacion where Id_FichaIdentificacion = @Id_FichaIdentificacion";
            Helpers h = new Helpers();
            var oneFicha = h.GetAllParametized(query, new Tabla_Catalogo_FichaIdentificacionDTO { Id_FichaIdentificacion = Id_FichaIdentificacion })[0];
            lblNombre.Text = oneFicha.Nombre_FichaIdentificacion.Trim() + " " + oneFicha.ApPaterno_FichaIdentificacion.Trim() + " " + oneFicha.ApMaterno_FichaIdentificacion.Trim();
            NombreCompleto = oneFicha.Nombre_FichaIdentificacion.Trim() + " " + oneFicha.ApPaterno_FichaIdentificacion.Trim() + " " + oneFicha.ApMaterno_FichaIdentificacion.Trim();
        }


        protected void btnantecedentes_Click(object sender, EventArgs e)
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();
            SqlCommand comando = new SqlCommand(@"select count (Id_ConsultaAntecedentesNotas)from Tabla_Registro_ConsultaAntecedentesNotas
                                                  where Id_FichaIdentificacion=" + Id_FichaIdentificacion + "", cnn);


            comando.CommandType = CommandType.Text;
            int numerocount = Convert.ToInt32(comando.ExecuteScalar());
            comando = null;
            cnn.Close();

            cnn.Open();
            SqlCommand comando2 = new SqlCommand("SP_Registro_ConsultasAntecedentesNotas", cnn);
            comando2.CommandType = CommandType.StoredProcedure;

            if (numerocount == 0)
            {
                comando2.Parameters.AddWithValue("@Opcion", "INSERTAR");
                comando2.Parameters.AddWithValue("@Id_FichaIdentificacion", Id_FichaIdentificacion);
            }
            else
            {
                comando2.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                comando2.Parameters.AddWithValue("@Id_FichaIdentificacion", Id_FichaIdentificacion);
            }


            comando2.Parameters.AddWithValue("@Antecedentes_Relevantes", txtantecedentes.Text.Trim());
            comando2.Parameters.AddWithValue("@Notas_Relevantes", txtnotasrelevantes.Text.Trim());


            SqlDataReader reader = comando2.ExecuteReader();
            reader.Read();
            comando2 = null;
            cnn.Close();

            llenartxtantecedentesnotas();
        }

        public string testbind(object myValue)
        {
            if (myValue == null)
            {
                var strValue = "";
                if (strValue == "")
                {
                    return " ";
                }
            }
            return myValue.ToString();
        }

        protected string porConsultar(object myValue)
        {
            if (myValue == null)
            {
                var strValue = "";
                if (strValue == "")
                {
                    return " ";
                }
            }
            return myValue.ToString();
        }

        protected void upload(object sender, EventArgs e)
        {
            var oneFicha = FichaDAO.GetOne(new Tabla_Catalogo_FichaIdentificacionDTO { Id_FichaIdentificacion = Id_FichaIdentificacion });
            string pathToCreate = "~/Pacientes/" + oneFicha.Id_FichaIdentificacion;
            if (!Directory.Exists(Server.MapPath(pathToCreate)))
            {
                Directory.CreateDirectory(Server.MapPath(pathToCreate));
            }
            if (fleUpload.PostedFile != null)
            {
                fleUpload.SaveAs(Server.MapPath(pathToCreate) + "/" + fleUpload.PostedFile.FileName);
            }
            loadFile(oneFicha);
        }

        public void loadFile(Tabla_Catalogo_FichaIdentificacionDTO oneFicha)
        {
            string pathToCreate = "~/Pacientes/" + oneFicha.Id_FichaIdentificacion;
            if (!Directory.Exists(Server.MapPath(pathToCreate)))
            {
                Directory.CreateDirectory(Server.MapPath(pathToCreate));
            }
            string[] fileEntries = Directory.GetFiles(Server.MapPath(pathToCreate));
            var lFiles = new List<FileDTO>();

            foreach (string fileName in fileEntries)
            {
                FileDTO oneFile = new FileDTO();
                oneFile.Nombre = fileName.Remove(0, Server.MapPath(pathToCreate).Count() + 1);
                oneFile.Download = fileName;
                lFiles.Add(oneFile);
            }
            rptFiles.DataSource = lFiles;
            rptFiles.DataBind();
        }

    }
}
