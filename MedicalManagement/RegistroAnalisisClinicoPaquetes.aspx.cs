using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace MedicalManagement
{
    public partial class RegistroAnalisisClinicoPaquetes : System.Web.UI.Page
    {
        int Id_AnalisisClinicoPaquetes = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_AnalisisClinicoPaquetes"]);
        private const string CHECKED_ITEMS = "CheckedItems";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LlenarGridAnalisisClinico();
                Mostrar(Convert.ToString(Id_AnalisisClinicoPaquetes));


                if (Id_AnalisisClinicoPaquetes != 0)
                {

                    /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
                    string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                    SqlConnection cnn;
                    cnn = new SqlConnection(conexion);
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("SP_Catalogo_AnalisisClinicoPaquetes", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Opcion", "ENCONTRAR");
                    comando.Parameters.AddWithValue("@Id_AnalisisClinicoPaquetes", Id_AnalisisClinicoPaquetes);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        Descripcion_AnalisisClinicoPaquetes.Text = reader.GetString(reader.GetOrdinal("Descripcion_AnalisisClinicoPaquetes")).Trim();

                    }

                    reader.Close();
                    comando = null;
                    cnn.Close();


                }

            }

        }
        ////////////Parte de Grid Analisis Clinicos ////////////////////////////////////////////////////////////////

        protected void txt_OnTextChanged(object sender, EventArgs e)
        {
            LlenarGridAnalisisClinico();
        }


        protected void Grid_AnalisisClinico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //RecuperaChequeados();

            

            Grid_AnalisisClinico.PageIndex = e.NewPageIndex;
            Grid_AnalisisClinico.DataBind();

            LlenarGridAnalisisClinico();
            Mostrar(Convert.ToString( Id_AnalisisClinicoPaquetes));
            //ReMarcaValues();
        }

        protected void Grid_AnalisisClinico_PageIndexChanged(object sender, EventArgs e)//EventArgs
        {
            
            LlenarGridAnalisisClinico();
            Mostrar(Convert.ToString(Id_AnalisisClinicoPaquetes));
        }

        protected void CheckBoxelegir_CheckedChanged(object sender, EventArgs e)
        {
            if (Descripcion_AnalisisClinicoPaquetes.Text.Trim().Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado: Favor de Capturar el Nombre del Paquete de Analisis Clinico</p>";
            }

            else
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: white\"></p>";
                GrabaAnalisisClinicoPaquetes();
                Mostrar(Convert.ToString( Id_AnalisisClinicoPaquetes));
            }
        
        }

        //protected void CheckBoxelegir_CheckedChanged(object sender, EventArgs e)
        //{
        //    DataTable ds = new DataTable();
        //    ds.Columns.Add("Id_AnalisisClinico", typeof(Int32));
        //    ds.Columns.Add("Descripcion_AnalisisClinico", typeof(String));

        //    string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

        //    SqlConnection cnn;
        //    cnn = new SqlConnection(conexion);

        //    cnn.Open();


        //    CheckBox chseleccionado;

        //    foreach (GridViewRow row in Grid_AnalisisClinico.Rows)
        //    {
        //        bool valorcheck = false;

        //        chseleccionado = row.FindControl("CheckBoxelegir") as CheckBox;
        //        valorcheck = chseleccionado.Checked;
        //        if (valorcheck == true)
        //        {
        //            int Id_analisisclinico = Convert.ToInt32(row.Cells[0].Text);
        //            string Descripcion_AnalisisClinico = Convert.ToString(row.Cells[1].Text);


        //            //                    string sentencia = @"select Id_AnalisisClinico,Descripcion_AnalisisClinico from Tabla_Catalogo_AnalisisClinico 
        //            //                                        where Id_AnalisisClinico="+Id_analisisclinico+"";

        //            //                    SqlCommand comando = new SqlCommand(sentencia, cnn);

        //            //                    SqlDataAdapter da = new SqlDataAdapter(comando);


        //            DataRow fila = ds.NewRow();
        //            fila["Id_AnalisisClinico"] = Id_analisisclinico;
        //            fila["Descripcion_AnalisisClinico"] = Descripcion_AnalisisClinico;

        //            ds.Rows.Add(fila);


        //        }
        //        else
        //        {
        //            //chseleccionado.Checked = false;
        //        }
        //    }

        //    Grid_AnalisisClinicoSeleccionado.Visible = true;
        //    Grid_AnalisisClinicoSeleccionado.DataSource = ds;
        //    //Grid_AnalisisClinicoSeleccionado.Columns[0].Visible = true;
        //    //Grid_AnalisisClinicoSeleccionado.Columns[1].Visible = true;
        //    //Grid_AnalisisClinicoSeleccionado.Columns[2].Visible = true;
        //    Grid_AnalisisClinicoSeleccionado.DataBind();

        //    cnn.Close();
            
        //}

        ///////////////////////////////////////////////////////////////////////////////////////

        protected void btnRegresar_AnalisisClinicoPaquetes_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnalisisClinicoPaquetes.aspx");
        }

        

        protected void btnGuardar_AnalisisClinicoPaquetes_Click(object sender, EventArgs e)
        {
            if (Descripcion_AnalisisClinicoPaquetes.Text.Trim().Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado: Favor de Capturar el Nombre del Paquete de Analisis Clinico</p>";
            }

            else
            {
                GrabaAnalisisClinicoPaquetes();
            }
            
        }

        protected void GrabaAnalisisClinicoPaquetes()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando = new SqlCommand("SP_Catalogo_AnalisisClinicoPaquetes", cnn);
            comando.CommandType = CommandType.StoredProcedure;           


            

            bool insertarIdAnalisisclinicoPaquetes = false;

            if (Id_AnalisisClinicoPaquetes == 0)
            {
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
                insertarIdAnalisisclinicoPaquetes = true;
            }
            else
            {
                comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                comando.Parameters.AddWithValue("@Id_AnalisisClinicoPaquetes", Id_AnalisisClinicoPaquetes);
                
            }

            comando.Parameters.AddWithValue("@Descripcion_AnalisisClinicoPaquetes", Descripcion_AnalisisClinicoPaquetes.Text);


            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            reader.Close();
            comando = null;

            ///////////////////////////////////////

            if (insertarIdAnalisisclinicoPaquetes == true)
            {
                string sentenciaId = @"select max(Id_AnalisisClinicoPaquetes) from Tabla_Catalogo_AnalisisClinicoPaquetes where 
                                     Descripcion_AnalisisClinicoPaquetes='"+Descripcion_AnalisisClinicoPaquetes.Text.Trim()+"'";
                SqlCommand comandoid = new SqlCommand(sentenciaId, cnn);
                int numeroidAnalisisClinicoPaquete = Convert.ToInt32(comandoid.ExecuteScalar());
                Session["numeroidAnalisisClinicoPaquete"] = numeroidAnalisisClinicoPaquete;
                Id_AnalisisClinicoPaquetes = numeroidAnalisisClinicoPaquete;
            }
            ///////////////////////////////////////

            string sentencia = @"select Id_AnalisisClinico from Tabla_Registro_AnalisisClinicoPaquetes
                                         where Id_AnalisisClinicoPaquetes=" + Id_AnalisisClinicoPaquetes + "";
            SqlCommand comandoselect = new SqlCommand(sentencia, cnn);

            SqlDataAdapter da = new SqlDataAdapter(comandoselect);
            DataTable ds = new DataTable();
            da.Fill(ds);

            if (ds.Rows.Count == 0)//Insertar datos a Tabla_registro_consultaanalisisclinicopaquetes 
            {
                foreach (GridViewRow row in Grid_AnalisisClinico.Rows)
                {
                    CheckBox chseleccionado;
                    bool varlorcheck = false;

                    int Numeroid_AnalisisClinicoGrid = Convert.ToInt32(row.Cells[0].Text);

                    chseleccionado = row.FindControl("CheckBoxelegir") as CheckBox;
                    if (chseleccionado.Checked == true)
                    {
                        //varlorcheck = true;
                        SqlCommand comando3 = new SqlCommand(@"insert into tabla_registro_AnalisisClinicoPaquetes (Id_AnalisisClinicoPaquetes,Id_AnalisisClinico,Estatus_AnalisisClinicoPaquetes)
                                                             values (" + Id_AnalisisClinicoPaquetes + "," + Numeroid_AnalisisClinicoGrid + ",1)", cnn);
                        comando3.CommandType = CommandType.Text;
                        SqlDataReader reader3 = comando3.ExecuteReader();

                        reader3.Read();
                        reader3.Close();
                    }
                    else
                    {
                        //varlorcheck = false;
                    }


                }
            }
            else
            {

                foreach (GridViewRow row in Grid_AnalisisClinico.Rows)
                {

                    CheckBox chseleccionado;
                    bool varlorcheck = false;

                    int Numeroid_AnalisisClinicoGrid = Convert.ToInt32(row.Cells[0].Text);

                    chseleccionado = row.FindControl("CheckBoxelegir") as CheckBox;
                    if (chseleccionado.Checked == true)
                    {



                        bool insertar = false;

                        foreach (DataRow dtRow in ds.Rows)
                        {
                            int NumeroidAnalisisClinicoTabla = 0;
                            NumeroidAnalisisClinicoTabla = Convert.ToInt32(dtRow["Id_AnalisisClinico"]);

                            insertar = true;

                            if (Numeroid_AnalisisClinicoGrid == NumeroidAnalisisClinicoTabla)
                            {
                                insertar = false;
                                SqlCommand comando3 = new SqlCommand(@"update tabla_Registro_AnalisisClinicoPaquetes set Id_AnalisisClinicoPaquetes=" + Id_AnalisisClinicoPaquetes + @",Id_AnalisisClinico=" + NumeroidAnalisisClinicoTabla +
                                                                     @",Estatus_AnalisisClinicoPaquetes=1 
                                                                     where Id_AnalisisClinicoPaquetes=" + Id_AnalisisClinicoPaquetes + " and Id_AnalisisClinico=" + NumeroidAnalisisClinicoTabla + "", cnn);
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
                            SqlCommand comando3 = new SqlCommand(@"insert into tabla_registro_analisisclinicoPaquetes (Id_AnalisisClinicoPaquetes,Id_AnalisisClinico,Estatus_AnalisisClinicoPaquetes)
                                                                 values (" + Id_AnalisisClinicoPaquetes + "," + Numeroid_AnalisisClinicoGrid + ",1)", cnn);
                            comando3.CommandType = CommandType.Text;


                            //comando.Parameters.AddWithValue("@Id_AnalisisClinico", numeroid_AnalisisClinico);

                            SqlDataReader reader3 = comando3.ExecuteReader();
                            reader3.Read();
                            reader3.Close();

                        }
                    }
                    else
                    {
                        bool insertar = false;

                        foreach (DataRow dtRow in ds.Rows)
                        {
                            int NumeroidAnalisisClinicoTabla = 0;
                            NumeroidAnalisisClinicoTabla = Convert.ToInt32(dtRow["Id_AnalisisClinico"]);

                            insertar = true;

                            if (Numeroid_AnalisisClinicoGrid == NumeroidAnalisisClinicoTabla)
                            {
                                insertar = false;
                                SqlCommand comando3 = new SqlCommand(@"update tabla_Registro_AnalisisClinicoPaquetes set Id_AnalisisClinicoPaquetes=" + Id_AnalisisClinicoPaquetes + @",Id_AnalisisClinico=" + NumeroidAnalisisClinicoTabla +
                                                                     @",Estatus_AnalisisClinicoPaquetes=0 
                                                                     where Id_AnalisisClinicoPaquetes=" + Id_AnalisisClinicoPaquetes + " and Id_AnalisisClinico=" + NumeroidAnalisisClinicoTabla + "", cnn);
                                comando3.CommandType = CommandType.Text;


                                //comando.Parameters.AddWithValue("@Id_AnalisisClinico", numeroid_AnalisisClinico);

                                SqlDataReader reader3 = comando3.ExecuteReader();
                                reader3.Read();
                                reader3.Close();
                                break;
                            }
                            else
                            {
                            }
                        }
                       
                    }

                }
            }

            if (insertarIdAnalisisclinicoPaquetes == true)
            {
                int sessionidAnalisisClinicoPaquete = Convert.ToInt32(Session["numeroidAnalisisClinicoPaquete"]);
                Session["numeroidAnalisisClinicoPaquete"] = null;
                System.Web.HttpContext.Current.Response.Redirect("RegistroAnalisisClinicoPaquetes.aspx?Id_AnalisisClinicoPaquetes=" + sessionidAnalisisClinicoPaquete);
            }
        }

        

        /////////Metodo para Llenar Grid Analisis Clinico////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void LlenarGridAnalisisClinico()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();
            

            SqlCommand comando = new SqlCommand(@"select Id_AnalisisClinico,Descripcion_AnalisisClinico,Estatus_AnalisisClinicoPaquetes='false'  
                                                  from Tabla_catalogo_AnalisisClinico", cnn);
            comando.CommandType = CommandType.Text;


            //if (txtBuscar_AnalisisClinico.Text == "")
            //{
            //    comando.Parameters.AddWithValue("@Descripcion_AnalisisClinico", "");
            //}
            //else
            //{
            //    comando.Parameters.AddWithValue("@Descripcion_AnalisisClinico", txtBuscar_AnalisisClinico.Text);
            //}
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
            Grid_AnalisisClinico.Columns[2].Visible = true;
            Grid_AnalisisClinico.DataBind();
            
            CheckBox chseleccionado;



            string sentencia=   @"select Id_AnalisisClinico,Estatus_AnalisisClinicoPaquetes from Tabla_Registro_AnalisisClinicoPaquetes
                                   where   Estatus_AnalisisClinicoPaquetes=1 and Id_AnalisisClinicoPaquetes="+Id_AnalisisClinicoPaquetes+"";

           
            SqlCommand comandoselect = new SqlCommand(sentencia, cnn);

            SqlDataAdapter da2 = new SqlDataAdapter(comandoselect);
            DataTable ds2 = new DataTable();
            da2.Fill(ds2);

            foreach (GridViewRow row in Grid_AnalisisClinico.Rows)
            {
                int Numeroid_AnalisisClinicoGrid = Convert.ToInt32(row.Cells[0].Text);


                bool valorcheck = false;
                valorcheck = Convert.ToBoolean(row.Cells[2].Text);
                string valorcheck2 = (row.Cells[0].Text);
                string valorcheck3 = (row.Cells[1].Text);

                foreach (DataRow dtRow in ds2.Rows)
                {

                    int NumeroidAnalisisClinicoTabla = 0;
                    NumeroidAnalisisClinicoTabla = Convert.ToInt32(dtRow["Id_AnalisisClinico"]);

                    if (Numeroid_AnalisisClinicoGrid == NumeroidAnalisisClinicoTabla)
                    {
                        bool valorEstatusSeleccionado = false;
                        valorEstatusSeleccionado = Convert.ToBoolean(dtRow["Estatus_AnalisisClinicoPaquetes"]);

                        if (valorEstatusSeleccionado == true)
                        {
                            chseleccionado = row.FindControl("CheckBoxelegir") as CheckBox;
                            chseleccionado.Checked = true;
                            (row.Cells[2].Text) = true.ToString(); ;

                        }
                        else
                        {
                            (row.Cells[2].Text) = false.ToString(); ;
                        }
                    }
                }
                
            }

            Grid_AnalisisClinico.Columns[2].Visible = false;
            ds.Dispose();
            da.Dispose();
            ds2.Dispose();
            da2.Dispose();
            cnn.Close();

        }

        ///////////////////////Llenando gridseleccionado

        protected void Mostrar(string Id_AnalisisClinicoPaquetes)
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();

            string sentencia = @"select a.Id_AnalisisClinico,b.Descripcion_AnalisisClinico from Tabla_Registro_AnalisisClinicoPaquetes a
                               join Tabla_Catalogo_AnalisisClinico b on a.Id_AnalisisClinico=b.Id_AnalisisClinico
                               where Id_AnalisisClinicoPaquetes=" + Id_AnalisisClinicoPaquetes + "and a.Estatus_AnalisisClinicoPaquetes=1";

            SqlCommand comando = new SqlCommand(sentencia, cnn);
            comando.CommandType = CommandType.Text;


            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Grid_AnalisisClinicoSeleccionado.Visible = true;
            Grid_AnalisisClinicoSeleccionado.DataSource = ds;
            Grid_AnalisisClinicoSeleccionado.Columns[0].Visible = true;
            Grid_AnalisisClinicoSeleccionado.Columns[1].Visible = true;
            Grid_AnalisisClinicoSeleccionado.DataBind();
            ds.Dispose();
            da.Dispose();

            cnn.Close();

        }

        ///////////////////////Metodos pra mantener los checkbox seleccionados

        private void RecuperaChequeados()
        {
            ArrayList categoryIDList = new ArrayList();

            foreach (GridViewRow Row in Grid_AnalisisClinico.Rows)
            {
                int index1 = Convert.ToInt32(Row.RowIndex);
                string index = Grid_AnalisisClinico.Rows[index1].Cells[1].Text + index1.ToString();

                bool result = ((CheckBox)Row.FindControl("CheckBoxelegir")).Checked;

                // Check in the Session 
                if (Session[CHECKED_ITEMS] != null)
                    categoryIDList = (ArrayList)Session[CHECKED_ITEMS];
                if (result)
                {
                    if (!categoryIDList.Contains(index))
                        categoryIDList.Add(index);
                }
                else
                {
                    categoryIDList.Remove(index);
                }
                if (categoryIDList != null && categoryIDList.Count > 0)
                    Session[CHECKED_ITEMS] = categoryIDList;
            }
        }

        private void ReMarcaValues()
        {
            ArrayList categoryIDList = (ArrayList)Session[CHECKED_ITEMS];
            if (categoryIDList != null && categoryIDList.Count > 0)
            {
                foreach (GridViewRow row in Grid_AnalisisClinico.Rows)
                {
                    int index1 = Convert.ToInt32(row.RowIndex);
                    string index = Grid_AnalisisClinico.Rows[index1].Cells[1].Text + index1.ToString();
                    if (categoryIDList.Contains(index))
                    {
                        CheckBox myCheckBox = (CheckBox)row.FindControl("CheckBoxelegir");
                        myCheckBox.Checked = true;
                    }
                }
            }
        }
    }
}