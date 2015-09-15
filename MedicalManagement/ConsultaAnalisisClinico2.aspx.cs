using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MedicalManagement
{
    public partial class ConsultaAnalisisClinico2 : System.Web.UI.Page
    {
        int Id_Agenda = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Agenda"]);
        int Id_FichaIdentificacion = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_FichaIdentificacion"]);
        string NombreCompleto = Convert.ToString(System.Web.HttpContext.Current.Request.QueryString["NombreCompleto"]);

        int Id_Consulta = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Consulta"]);
        int Id_ConsultaAnalisisClinico = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            if (!IsPostBack)
            {
                LlenarGridAnalisisClinico();
                LlenarGridAnalisisClinicoPaquetes();

                SqlConnection cnn;
                cnn = new SqlConnection(conexion);
                cnn.Open();

                string consulta = "select Id_ConsultaAnalisisClinico from Tabla_Registro_ConsultaAnalisisClinico where Id_Consulta=" + Id_Consulta + "";
                SqlCommand comando = new SqlCommand(consulta, cnn);
                Id_ConsultaAnalisisClinico = Convert.ToInt32(comando.ExecuteScalar());
                Session["Id_ConsultaAnalisisClinico"] = Id_ConsultaAnalisisClinico;

                if (Id_ConsultaAnalisisClinico != 0)
                {
                    /////////////LLenando Grid Analisis Clinico Seleccionado

                    SqlCommand comando2 = new SqlCommand("SP_Registro_ConsultasAnalisisClinicos", cnn);
                    comando2.CommandType = CommandType.StoredProcedure;
                    comando2.Parameters.AddWithValue("@Opcion", "ENCONTRAR");
                    comando2.Parameters.AddWithValue("@Id_ConsultaAnalisisClinico", Id_ConsultaAnalisisClinico);
                    SqlDataReader reader = comando2.ExecuteReader();
                    if (reader.Read())
                    {
                        txtobservacionesanalisisclinico.Text = reader.GetString(reader.GetOrdinal("Observaciones_ConsultaAnalisisClinico")).ToString().Trim();
                        //txtmedicamento.Text = reader.GetString(reader.GetOrdinal("Medicamento_ConsultaReceta")).ToString();
                        //txtdosis.Text = reader.GetString(reader.GetOrdinal("Dosis_ConsultaReceta")).ToString().Trim();
                        //txtnotas.Text = reader.GetString(reader.GetOrdinal("Notas_ConsultaReceta")).ToString().Trim();

                    }

                    reader.Read();
                    reader.Close();
                    comando2 = null;

                    string sentencia = @"select a.Id_AnalisisClinico, b.Descripcion_AnalisisClinico from Tabla_Registro_ConsultaAnalisisClinicoDetallado a
                                     join Tabla_Catalogo_AnalisisClinico b on a.Id_AnalisisClinico= b.Id_AnalisisClinico
                                     where a.Id_ConsultaAnalisisClinico=" + Id_ConsultaAnalisisClinico + "and a.Estatus_ConsultaAnalisisClinicoDetallado=1";//Id_ConsultaAnalisisClinico se utiliza en caso de que este no sea cero

                    SqlCommand comandoselect = new SqlCommand(sentencia, cnn);

                    SqlDataAdapter da = new SqlDataAdapter(comandoselect);
                    DataTable ds = new DataTable();
                    da.Fill(ds);
                    Grid_AnalisisClinicoSeleccionado.Visible = true;
                    Grid_AnalisisClinicoSeleccionado.DataSource = ds;
                    Grid_AnalisisClinicoSeleccionado.Columns[0].Visible = true;
                    Grid_AnalisisClinicoSeleccionado.Columns[1].Visible = true;
                    Grid_AnalisisClinicoSeleccionado.DataBind();
                    ds.Dispose();
                    da.Dispose();

                    /////////////LLenando Grid Analisis Clinico Seleccionado Paquetes

                    sentencia = null;
                    comandoselect = null;
                    da = null;
                    ds = null;

                    sentencia = @"select a.Id_AnalisisClinicoPaquetes, b.Descripcion_AnalisisClinicoPaquetes from Tabla_Registro_ConsultaAnalisisClinicoDetalladoPaquetes a
                                     join Tabla_Catalogo_AnalisisClinicoPaquetes b on a.Id_AnalisisClinicoPaquetes= b.Id_AnalisisClinicoPaquetes
                                     where a.Id_ConsultaAnalisisClinico=" + Id_ConsultaAnalisisClinico + "and a.Estatus_ConsultaAnalisisClinicoDetalladoPaquetes=1";//Id_ConsultaAnalisisClinico se utiliza en caso de que este no sea cero

                    comandoselect = new SqlCommand(sentencia, cnn);

                    da = new SqlDataAdapter(comandoselect);
                    ds = new DataTable();
                    da.Fill(ds);
                    Grid_AnalisisClinicoSeleccionadoPaquetes.Visible = true;
                    Grid_AnalisisClinicoSeleccionadoPaquetes.DataSource = ds;
                    Grid_AnalisisClinicoSeleccionadoPaquetes.Columns[0].Visible = true;
                    Grid_AnalisisClinicoSeleccionadoPaquetes.Columns[1].Visible = true;
                    Grid_AnalisisClinicoSeleccionadoPaquetes.DataBind();
                    ds.Dispose();
                    da.Dispose();
                }
                else
                {

                    DateTime hoy = DateTime.Now;
                    //fecha_actual = hoy.ToString("dd-MM-yyyy HH:mm:ss");
                    //txtfechaconsulta.Text = fecha_actual;
                    //txtnombre.Text = NombreCompleto;

                }
                cnn.Close();
            }

        }


        ///////////////////////////////////////////////////////////////////////////////////////

        protected void btnRegresar_ConsultasAnalisisClinico_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Consultas.aspx");
        }

        protected void btnGuardar_ConsultasAnalisisClinico_Click(object sender, EventArgs e)
        {
            GuardarConsultaAnalisisClinico();
        }

        public void GuardarConsultaAnalisisClinico()
        {
            //Insertar o Actualizar datos en tabla_registro_consultaanalisisclinico

            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();

            SqlCommand comando = new SqlCommand("SP_Registro_ConsultasAnalisisClinicos", cnn);
            comando.CommandType = CommandType.StoredProcedure;


            Id_ConsultaAnalisisClinico = Convert.ToInt32(Session["Id_ConsultaAnalisisClinico"]);

            if (Id_ConsultaAnalisisClinico == 0)
            {
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");

            }
            else
            {

                comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                comando.Parameters.AddWithValue("@Id_ConsultaAnalisisClinico", Id_ConsultaAnalisisClinico);

            }

            comando.Parameters.AddWithValue("@Id_Consulta", Id_Consulta);
            comando.Parameters.AddWithValue("@Observaciones_ConsultaAnalisisClinico", txtobservacionesanalisisclinico.Text.Trim());//@Observaciones_ConsultaAnalisisClinico

            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            reader.Close();
            comando = null;

            ////////////////////////////////////

            //Insertar o Actualizar datos en Tabla_registro_consultaanalisisclinicodetallado

            string consulta4 = "select Id_ConsultaAnalisisClinico from Tabla_Registro_ConsultaAnalisisClinico where Id_Consulta=" + Id_Consulta + "";
            SqlCommand comando4 = new SqlCommand(consulta4, cnn);
            int Id_ConsultaAnalisisClinicoSentencia = Convert.ToInt32(comando4.ExecuteScalar());//>>>Id_ConsultaAnalisisClinicoSentencia sirve para obtener Id_ConsultaAnalisisClinico, una vez que ya se haya insertado o actualizado en el Sqlreader llamado "reader"


            string sentencia = @"select Id_AnalisisClinico from tabla_registro_consultaanalisisclinicodetallado
                                         where Id_ConsultaAnalisisClinico=" + Id_ConsultaAnalisisClinicoSentencia + "";
            SqlCommand comandoselect = new SqlCommand(sentencia, cnn);

            SqlDataAdapter da = new SqlDataAdapter(comandoselect);
            DataTable ds = new DataTable();
            da.Fill(ds);

            if (ds.Rows.Count == 0)//Insertar datos a Tabla_registro_consultaanalisisclinicodetallado 
            {
                foreach (GridViewRow row in Grid_AnalisisClinicoSeleccionado.Rows)
                {
                    int Numeroid_AnalisisClinicoGrid = Convert.ToInt32(row.Cells[0].Text);

                    SqlCommand comando3 = new SqlCommand(@"insert into tabla_registro_consultaanalisisclinicodetallado (Id_ConsultaAnalisisClinico,Id_AnalisisClinico,Estatus_ConsultaAnalisisClinicoDetallado)
                                                             values (" + Id_ConsultaAnalisisClinicoSentencia + "," + Numeroid_AnalisisClinicoGrid + ",1)", cnn);
                    comando3.CommandType = CommandType.Text;
                    SqlDataReader reader3 = comando3.ExecuteReader();

                    reader3.Read();
                    reader3.Close();

                }
            }
            else
            {
                SqlCommand comando2 = new SqlCommand(@"update tabla_registro_consultaanalisisclinicodetallado set Estatus_ConsultaAnalisisClinicoDetallado=0 
                                                       where Id_ConsultaAnalisisClinico=" + Id_ConsultaAnalisisClinicoSentencia + "", cnn);
                comando2.CommandType = CommandType.Text;
                SqlDataReader reader2 = comando2.ExecuteReader();
                reader2.Read();
                reader2.Close();

                foreach (GridViewRow row in Grid_AnalisisClinicoSeleccionado.Rows)
                {
                    int Numeroid_AnalisisClinicoGrid = Convert.ToInt32(row.Cells[0].Text);


                    bool insertar = false;

                    foreach (DataRow dtRow in ds.Rows)
                    {
                        int NumeroidAnalisisClinicoTabla = 0;
                        NumeroidAnalisisClinicoTabla = Convert.ToInt32(dtRow["Id_AnalisisClinico"]);

                        insertar = true;

                        if (Numeroid_AnalisisClinicoGrid == NumeroidAnalisisClinicoTabla)
                        {
                            insertar = false;
                            SqlCommand comando3 = new SqlCommand(@"update tabla_registro_consultaanalisisclinicodetallado set Id_ConsultaAnalisisClinico=" + Id_ConsultaAnalisisClinicoSentencia + @",Id_AnalisisClinico=" + NumeroidAnalisisClinicoTabla +
                                                                 @",Estatus_ConsultaAnalisisClinicoDetallado=1 
                                                                     where Id_ConsultaAnalisisClinico=" + Id_ConsultaAnalisisClinicoSentencia + " and Id_AnalisisClinico=" + NumeroidAnalisisClinicoTabla + "", cnn);
                            comando3.CommandType = CommandType.Text;


                            //comando.Parameters.AddWithValue("@Id_AnalisisClinico", numeroid_AnalisisClinico);

                            SqlDataReader reader3 = comando3.ExecuteReader();
                            reader3.Read();
                            reader3.Close();
                            break;
                        }
                    }

                    if (insertar == true)
                    {
                        SqlCommand comando3 = new SqlCommand(@"insert into tabla_registro_consultaanalisisclinicodetallado (Id_ConsultaAnalisisClinico,Id_AnalisisClinico,Estatus_ConsultaAnalisisClinicoDetallado)
                                                                 values (" + Id_ConsultaAnalisisClinicoSentencia + "," + Numeroid_AnalisisClinicoGrid + ",1)", cnn);
                        comando3.CommandType = CommandType.Text;


                        //comando.Parameters.AddWithValue("@Id_AnalisisClinico", numeroid_AnalisisClinico);

                        SqlDataReader reader3 = comando3.ExecuteReader();
                        reader3.Read();
                        reader3.Close();

                    }

                }

            }


            /*
            String Registro_Operacion_Btacora = "";
            string Descripcion_Bitacora = "";
            if (Id_FichaIdentificacion == 0)
            {
                Registro_Operacion_Btacora = "SP_Catalogo_FichaIdentificacion"
                                                + "@Opcion" + " = " + "INSERTAR"
                                                + "@Descripcion_EdoCivil" + " = " + txtasunto.Text;
                Descripcion_Bitacora = "Inserta FichaIdentificacion nueva";
            }
            else
            {
                Registro_Operacion_Btacora = "SP_Catalogo_FichaIdentificacion"
                                                + "@Opcion" + " = " + "ACTUALIZAR"
                                                + "@Id_FichaIdentificacion" + " = " + Convert.ToString(Id_FichaIdentificacion).Trim()
                + "@Descripcion_EdoCivil" + " = " + txtasunto.Text;

                Descripcion_Bitacora = "Actualizar FichaIdentificacion";
            }
            SqlCommand comandoBitacora = new SqlCommand("SP_Registro_Bitacora", cnn);
            comandoBitacora.CommandType = CommandType.StoredProcedure;
            comandoBitacora.Parameters.AddWithValue("@Id_Empresa", Convert.ToInt32(Session["Id_Empresa"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Sucursal", Convert.ToInt32(Session["Id_Sucursal"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Usuario", Convert.ToInt32(Session["Id_Usuario"]));
            comandoBitacora.Parameters.AddWithValue("@Registro_Operacion_Btacora", Registro_Operacion_Btacora);
            comandoBitacora.Parameters.AddWithValue("@Descripcion_Bitacora", Descripcion_Bitacora);

            SqlDataReader readerBitacora = comandoBitacora.ExecuteReader();
            readerBitacora.Read();
            readerBitacora.Close();
            comandoBitacora = null;
            */

            cnn.Close();


            ////////Paquetes//////////////////////Insertar o Actualizar datos en tabla_registro_consultaanalisisclinico



            cnn.Open();



            ////////////////////////////////////

            consulta4 = null;
            consulta4 = null;
            Id_ConsultaAnalisisClinicoSentencia = 0;
            sentencia = null;
            comandoselect = null;
            da = null;
            ds = null;

            //Insertar o Actualizar datos en Tabla_registro_consultaanalisisclinicodetalladopaquetes

            consulta4 = "select Id_ConsultaAnalisisClinico from Tabla_Registro_ConsultaAnalisisClinico where Id_Consulta=" + Id_Consulta + "";
            comando4 = new SqlCommand(consulta4, cnn);
            Id_ConsultaAnalisisClinicoSentencia = Convert.ToInt32(comando4.ExecuteScalar());//>>>Id_ConsultaAnalisisClinicoSentencia sirve para obtener Id_ConsultaAnalisisClinico, una vez que ya se haya insertado o actualizado en el Sqlreader llamado "reader"


            sentencia = @"select Id_AnalisisClinicoPaquetes from tabla_registro_consultaanalisisclinicodetalladopaquetes
                                         where Id_ConsultaAnalisisClinico=" + Id_ConsultaAnalisisClinicoSentencia + "";
            comandoselect = new SqlCommand(sentencia, cnn);

            da = new SqlDataAdapter(comandoselect);
            ds = new DataTable();
            da.Fill(ds);

            if (ds.Rows.Count == 0)//Insertar datos a Tabla_registro_consultaanalisisclinicodetalladoPaquetes 
            {
                foreach (GridViewRow row in Grid_AnalisisClinicoSeleccionadoPaquetes.Rows)
                {
                    int Numeroid_AnalisisClinicoGrid = Convert.ToInt32(row.Cells[0].Text);

                    SqlCommand comando3 = new SqlCommand(@"insert into tabla_registro_consultaanalisisclinicodetalladoPaquetes (Id_ConsultaAnalisisClinico,Id_AnalisisClinicoPaquetes,Estatus_ConsultaAnalisisClinicoDetalladoPaquetes)
                                                             values (" + Id_ConsultaAnalisisClinicoSentencia + "," + Numeroid_AnalisisClinicoGrid + ",1)", cnn);
                    comando3.CommandType = CommandType.Text;
                    SqlDataReader reader3 = comando3.ExecuteReader();

                    reader3.Read();
                    reader3.Close();

                }
            }
            else
            {
                SqlCommand comando2 = new SqlCommand(@"update tabla_registro_consultaanalisisclinicodetalladoPaquetes set Estatus_ConsultaAnalisisClinicoDetalladoPaquetes=0 
                                                       where Id_ConsultaAnalisisClinico=" + Id_ConsultaAnalisisClinicoSentencia + "", cnn);
                comando2.CommandType = CommandType.Text;
                SqlDataReader reader2 = comando2.ExecuteReader();
                reader2.Read();
                reader2.Close();

                foreach (GridViewRow row in Grid_AnalisisClinicoSeleccionadoPaquetes.Rows)
                {
                    int Numeroid_AnalisisClinicoGrid = Convert.ToInt32(row.Cells[0].Text);


                    bool insertar = false;

                    foreach (DataRow dtRow in ds.Rows)
                    {
                        int NumeroidAnalisisClinicoTabla = 0;
                        NumeroidAnalisisClinicoTabla = Convert.ToInt32(dtRow["Id_AnalisisClinicoPaquetes"]);

                        insertar = true;

                        if (Numeroid_AnalisisClinicoGrid == NumeroidAnalisisClinicoTabla)
                        {
                            insertar = false;
                            SqlCommand comando3 = new SqlCommand(@"update tabla_registro_consultaanalisisclinicodetalladoPaquetes set Id_ConsultaAnalisisClinico=" + Id_ConsultaAnalisisClinicoSentencia + @",Id_AnalisisClinicoPaquetes=" + NumeroidAnalisisClinicoTabla +
                                                                 @",Estatus_ConsultaAnalisisClinicoDetalladoPaquetes=1 
                                                                     where Id_ConsultaAnalisisClinico=" + Id_ConsultaAnalisisClinicoSentencia + " and Id_AnalisisClinicoPaquetes=" + NumeroidAnalisisClinicoTabla + "", cnn);
                            comando3.CommandType = CommandType.Text;


                            //comando.Parameters.AddWithValue("@Id_AnalisisClinico", numeroid_AnalisisClinico);

                            SqlDataReader reader3 = comando3.ExecuteReader();
                            reader3.Read();
                            reader3.Close();
                            break;
                        }
                    }

                    if (insertar == true)
                    {
                        SqlCommand comando3 = new SqlCommand(@"insert into tabla_registro_consultaanalisisclinicodetalladoPaquetes (Id_ConsultaAnalisisClinico,Id_AnalisisClinicoPaquetes,Estatus_ConsultaAnalisisClinicoDetalladoPaquetes)
                                                                 values (" + Id_ConsultaAnalisisClinicoSentencia + "," + Numeroid_AnalisisClinicoGrid + ",1)", cnn);
                        comando3.CommandType = CommandType.Text;


                        //comando.Parameters.AddWithValue("@Id_AnalisisClinico", numeroid_AnalisisClinico);

                        SqlDataReader reader3 = comando3.ExecuteReader();
                        reader3.Read();
                        reader3.Close();

                    }

                }

            }


            /*
            String Registro_Operacion_Btacora = "";
            string Descripcion_Bitacora = "";
            if (Id_FichaIdentificacion == 0)
            {
                Registro_Operacion_Btacora = "SP_Catalogo_FichaIdentificacion"
                                                + "@Opcion" + " = " + "INSERTAR"
                                                + "@Descripcion_EdoCivil" + " = " + txtasunto.Text;
                Descripcion_Bitacora = "Inserta FichaIdentificacion nueva";
            }
            else
            {
                Registro_Operacion_Btacora = "SP_Catalogo_FichaIdentificacion"
                                                + "@Opcion" + " = " + "ACTUALIZAR"
                                                + "@Id_FichaIdentificacion" + " = " + Convert.ToString(Id_FichaIdentificacion).Trim()
                + "@Descripcion_EdoCivil" + " = " + txtasunto.Text;

                Descripcion_Bitacora = "Actualizar FichaIdentificacion";
            }
            SqlCommand comandoBitacora = new SqlCommand("SP_Registro_Bitacora", cnn);
            comandoBitacora.CommandType = CommandType.StoredProcedure;
            comandoBitacora.Parameters.AddWithValue("@Id_Empresa", Convert.ToInt32(Session["Id_Empresa"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Sucursal", Convert.ToInt32(Session["Id_Sucursal"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Usuario", Convert.ToInt32(Session["Id_Usuario"]));
            comandoBitacora.Parameters.AddWithValue("@Registro_Operacion_Btacora", Registro_Operacion_Btacora);
            comandoBitacora.Parameters.AddWithValue("@Descripcion_Bitacora", Descripcion_Bitacora);

            SqlDataReader readerBitacora = comandoBitacora.ExecuteReader();
            readerBitacora.Read();
            readerBitacora.Close();
            comandoBitacora = null;
            */

            cnn.Close();

            Response.Redirect("ConsultaMenu.aspx?Id_Agenda=" + Id_Agenda + " &Id_FichaIdentificacion=" + Id_FichaIdentificacion + " &NombreCompleto=" + NombreCompleto + "&Id_Consulta=" + Id_Consulta + "");

        }



        ////////////Parte de Grid Analisis Clinicos sin paquetes////////////////////////////////////////////////////////////////


        protected void txt_OnTextChanged(object sender, EventArgs e)
        {
            LlenarGridAnalisisClinico();
        }


        protected void Grid_AnalisisClinico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LlenarGridAnalisisClinico();

            Grid_AnalisisClinico.PageIndex = e.NewPageIndex;
            Grid_AnalisisClinico.DataBind();
        }

        protected void Grid_AnalisisClinico_PageIndexChanged(object sender, EventArgs e)//EventArgs
        {

        }


        protected void CheckBoxelegir_CheckedChanged(object sender, EventArgs e)
        {

            DataTable ds = new DataTable();
            ds.Columns.Add("Id_AnalisisClinico", typeof(Int32));
            ds.Columns.Add("Descripcion_AnalisisClinico", typeof(String));

            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();


            CheckBox chseleccionado;

            foreach (GridViewRow row in Grid_AnalisisClinico.Rows)
            {
                bool valorcheck = false;

                chseleccionado = row.FindControl("CheckBoxelegir") as CheckBox;
                valorcheck = chseleccionado.Checked;
                if (valorcheck == true)
                {
                    int Id_analisisclinico = Convert.ToInt32(row.Cells[0].Text);
                    string Descripcion_AnalisisClinico = Convert.ToString(row.Cells[1].Text);


                    //                    string sentencia = @"select Id_AnalisisClinico,Descripcion_AnalisisClinico from Tabla_Catalogo_AnalisisClinico 
                    //                                        where Id_AnalisisClinico="+Id_analisisclinico+"";

                    //                    SqlCommand comando = new SqlCommand(sentencia, cnn);

                    //                    SqlDataAdapter da = new SqlDataAdapter(comando);


                    DataRow fila = ds.NewRow();
                    fila["Id_AnalisisClinico"] = Id_analisisclinico;
                    fila["Descripcion_AnalisisClinico"] = Descripcion_AnalisisClinico;

                    ds.Rows.Add(fila);


                }
                else
                {
                    //chseleccionado.Checked = false;
                }
            }

            Grid_AnalisisClinicoSeleccionado.Visible = true;
            Grid_AnalisisClinicoSeleccionado.DataSource = ds;
            //Grid_AnalisisClinicoSeleccionado.Columns[0].Visible = true;
            //Grid_AnalisisClinicoSeleccionado.Columns[1].Visible = true;
            //Grid_AnalisisClinicoSeleccionado.Columns[2].Visible = true;
            Grid_AnalisisClinicoSeleccionado.DataBind();

            cnn.Close();

        }

        /////////Parte de Grid Analisis Clinicos con Paquetes////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void txt_OnTextChangedPaquetes(object sender, EventArgs e)
        {
            LlenarGridAnalisisClinicoPaquetes();
        }


        protected void Grid_AnalisisClinicoPaquetes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LlenarGridAnalisisClinicoPaquetes();

            Grid_AnalisisClinicoPaquetes.PageIndex = e.NewPageIndex;
            Grid_AnalisisClinicoPaquetes.DataBind();
        }

        protected void Grid_AnalisisClinicoPaquetes_PageIndexChanged(object sender, EventArgs e)//EventArgs
        {

        }

        protected void CheckBoxelegirPaquetes_CheckedChanged(object sender, EventArgs e)
        {
            DataTable ds = new DataTable();
            ds.Columns.Add("Id_AnalisisClinicoPaquetes", typeof(Int32));
            ds.Columns.Add("Descripcion_AnalisisClinicoPaquetes", typeof(String));

            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();


            CheckBox chseleccionado;

            foreach (GridViewRow row in Grid_AnalisisClinicoPaquetes.Rows)
            {
                bool valorcheck = false;

                chseleccionado = row.FindControl("CheckBoxelegirPaquetes") as CheckBox;
                valorcheck = chseleccionado.Checked;
                if (valorcheck == true)
                {
                    int Id_analisisclinicoPaquetes = Convert.ToInt32(row.Cells[0].Text);
                    string Descripcion_AnalisisClinicoPaquetes = Convert.ToString(row.Cells[1].Text);


                    //                    string sentencia = @"select Id_AnalisisClinico,Descripcion_AnalisisClinico from Tabla_Catalogo_AnalisisClinico 
                    //                                        where Id_AnalisisClinico="+Id_analisisclinico+"";

                    //                    SqlCommand comando = new SqlCommand(sentencia, cnn);

                    //                    SqlDataAdapter da = new SqlDataAdapter(comando);


                    DataRow fila = ds.NewRow();
                    fila["Id_AnalisisClinicoPaquetes"] = Id_analisisclinicoPaquetes;
                    fila["Descripcion_AnalisisClinicoPaquetes"] = Descripcion_AnalisisClinicoPaquetes;

                    ds.Rows.Add(fila);


                }
                else
                {
                    //chseleccionado.Checked = false;
                }
            }

            Grid_AnalisisClinicoSeleccionadoPaquetes.Visible = true;
            Grid_AnalisisClinicoSeleccionadoPaquetes.DataSource = ds;
            //Grid_AnalisisClinicoSeleccionadoPaquetes.Columns[0].Visible = true;
            //Grid_AnalisisClinicoSeleccionadoPaquetes.Columns[1].Visible = true;
            //Grid_AnalisisClinicoSeleccionadoPaquetes.Columns[2].Visible = true;
            Grid_AnalisisClinicoSeleccionadoPaquetes.DataBind();

            cnn.Close();


        }

        /////////Metodo para Llenar Grid Analisis Clinico////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void LlenarGridAnalisisClinico()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();

            SqlCommand comando = new SqlCommand("SP_Catalogo_AnalisisClinico", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Opcion", "LISTADO");
            if (txtBuscar_AnalisisClinico.Text == "")
            {
                comando.Parameters.AddWithValue("@Descripcion_AnalisisClinico", "");
            }
            else
            {
                comando.Parameters.AddWithValue("@Descripcion_AnalisisClinico", txtBuscar_AnalisisClinico.Text);
            }
            /*
                0  Id_Empresa
                1  Nombre_Empresa
             */

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Grid_AnalisisClinico.Visible = true;
            Grid_AnalisisClinico.DataSource = ds;
            Grid_AnalisisClinico.Columns[0].Visible = true;
            Grid_AnalisisClinico.Columns[1].Visible = true;
            Grid_AnalisisClinico.DataBind();
            ds.Dispose();
            da.Dispose();

        }

        /////////Metodo para Llenar Grid Analisis Clinico con Paquetes/////////////////////////////////////////////////////////////////////////////////

        protected void LlenarGridAnalisisClinicoPaquetes()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();

            SqlCommand comando = new SqlCommand("SP_Catalogo_AnalisisClinicoPaquetes", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Opcion", "LISTADO");
            if (txtBuscar_AnalisisClinicoPaquetes.Text == "")
            {
                comando.Parameters.AddWithValue("@Descripcion_AnalisisClinicoPaquetes", "");
            }
            else
            {
                comando.Parameters.AddWithValue("@Descripcion_AnalisisClinicoPaquetes", txtBuscar_AnalisisClinicoPaquetes.Text);
            }
            /*
                0  Id_Empresa
                1  Nombre_Empresa
             */

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Grid_AnalisisClinicoPaquetes.Visible = true;
            Grid_AnalisisClinicoPaquetes.DataSource = ds;
            Grid_AnalisisClinicoPaquetes.Columns[0].Visible = true;
            Grid_AnalisisClinicoPaquetes.Columns[1].Visible = true;
            Grid_AnalisisClinicoPaquetes.DataBind();
            ds.Dispose();
            da.Dispose();


        }
    }
}