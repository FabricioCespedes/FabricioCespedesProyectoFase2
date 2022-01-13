using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LogicaNegocio
{
    public class LNHorarios
    {
        string cadConexion;
        //DataTable Horarios;
        //DataSet setHorarios;
        ADHorarios aDHorarios;
        List<EGrupo> listaGrupos;
        List<EMateria> listaMaterias;
        List<EProfesor> listaProfesores;
        List<EAula> listaAulas;
        int cantidadLeccionesRequeridas = 0;
        /// <summary>
        /// Constructor de la lógica de negocio de laclase Horarios. Recibe 
        /// </summary>
        /// <param name="cadConexion"></param>
        public LNHorarios(string cadConexion)
        {
            this.cadConexion = cadConexion;
            aDHorarios = new ADHorarios(cadConexion);          
            listaProfesores = aDHorarios.listarProfesores();
            listaAulas = aDHorarios.listarAulas();
        }

        /// <summary>
        /// Método para crear horarios. Recibe por parámetro el año al que desea crear el horario.
        /// </summary>
        /// <param name="anio"></param>
        /// <returns></returns>
        public string  procesoCrearHorarios(int anio)
        {
            try
            {
                string condicion2 = $" anio = {anio}";
                listaGrupos = aDHorarios.listarGrupos(condicion2);
                foreach (EGrupo grupo in listaGrupos)
                {
                    if (grupo.Grado >= 12)
                    {
                        string condicion = " ORDER BY tipoAula desc";
                        listaMaterias = aDHorarios.listarMateriasOrdenada(condicion);
                        condicion = " order by tipoAula ";
                        listaAulas = aDHorarios.listarAulasOrdenada(condicion);
                    }
                    else
                    {
                        if (grupo.Grado == 11)
                        {
                            string condicion = " order by nombreMateria desc";
                            listaMaterias = aDHorarios.listarMateriasOrdenada(condicion);
                            condicion = " order by tipoAula ";
                            listaAulas = aDHorarios.listarAulasOrdenada(condicion);
                        }
                        else
                        {

                            string condicion = " ORDER BY tipoAula asc";
                            listaMaterias = aDHorarios.listarMateriasOrdenada(condicion);
                            condicion = " order by tipoAula desc ";
                            listaAulas = aDHorarios.listarAulasOrdenada(condicion);

                        }
                    }
                    recorrerMaterias(grupo);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return "Completado";
        }

        /// <summary>
        /// Método que recorre las materias para generar el horario. Recibe una clase grupo.
        /// </summary>
        /// <param name="grupo"></param>
        private void recorrerMaterias(EGrupo grupo)
        {
            EHorario horario = new EHorario();
            foreach (EMateria materia in listaMaterias)
            {
                horario.EMateria = materia;
                horario.EGrupo = grupo;
                recorrerGrado(horario);
            }
        }

        /// <summary>
        /// Método que recorre las materias y según el grado envía cantidad de lecciones. Recibe un horario.
        /// </summary>
        /// <param name="horario"></param>
        private void recorrerGrado(EHorario horario)
        {
            switch (horario.EGrupo.Grado)
            {
                case 7:
                case 8:
                case 9:
                    switch (horario.EMateria.NombreMateria)
                    {
                        case "ingles":
                            buscarLeccionesVacias(6, horario, 2, "Normal");
                            break;
                        case "español":
                        case "Estudios Sociales":
                        case "ciencias":
                        case "Matematicas":
                            buscarLeccionesVacias(4, horario, 2, "Normal");
                            break;
                        case "Educacion Financiera":
                            buscarLeccionesVacias(1, horario, 1, "Normal");
                            break;
                        case "Computacion":
                            buscarLeccionesVacias(2, horario, 2, "Computo");
                            break;
                        case "Contabilidad":
                            break;
                        case "Educacion Fisica":
                            buscarLeccionesVacias(2, horario, 2, "Normal");
                            break;
                        default:
                            buscarLeccionesVacias(2, horario, 2, "Normal");
                            break;
                    }
                    break;
                case 10:
                case 11:
                case 12:
                    switch (horario.EMateria.NombreMateria)
                    {
                        case "ingles":
                            buscarLeccionesVacias(6, horario, 2, "Normal");
                            break;
                        case "español":
                        case "Estudios Sociales":
                        case "ciencias":
                        case "Matematicas":
                           buscarLeccionesVacias(4, horario, 2, "Normal");
                            break;
                        case "Contabilidad":                            
                            buscarLeccionesVacias(12, horario, 4, "Contabilidad");
                            break;
                        case "Computacion":                       
                            buscarLeccionesVacias(12, horario, 4, "Computo");
                            break;
                        case "Educacion Fisica":
                            buscarLeccionesVacias(2, horario, 2, "Normal");
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        ///     Método en cargado de recorrer las cantidad de lecciones necesarias por materia, recibe cantitdad de lecciones, clase horario, cantidad minima de lecciones y tipo de aula.
        /// </summary>
        /// <param name="cantidadLecciones"></param>
        /// <param name="horario"></param>
        /// <param name="cantidadMinimaLecciones"></param>
        /// <param name="tipoAula"></param>
        private void buscarLeccionesVacias(int cantidadLecciones, EHorario horario, int cantidadMinimaLecciones, string tipoAula)
        {
            bool campoLeccionEncontrado = false;
            cantidadLeccionesRequeridas = cantidadLecciones;
            while (cantidadLecciones > 0)
            {
                campoLeccionEncontrado =  recorrerDias(cantidadMinimaLecciones, horario, tipoAula);

                if (campoLeccionEncontrado) cantidadLecciones = cantidadLecciones - cantidadMinimaLecciones;

            }
        }

        /// <summary>
        /// Método que recorre los días para producir el horario. Recibe cantidad minima de lecciones, clase horario y tipo aula.
        /// </summary>
        /// <param name="cantidadMinimaLecciones"></param>
        /// <param name="horario"></param>
        /// <param name="tipoAula"></param>
        /// <returns></returns>
        private bool recorrerDias(int cantidadMinimaLecciones, EHorario horario, string tipoAula)
        {
            string[] dias ;
            if (horario.EGrupo.Grado >= 12)
            {
                dias = new string[] { "V", "J", "M", "K", "L" };

            }
            else
            {
                if (horario.EGrupo.Grado >= 9)
                {
                    dias = new string[] { "J", "K", "V", "L", "M" };

                }
                else
                {
                    dias = new string[] { "L", "K", "M", "J", "V" };
                }
            }
            if (horario.EGrupo.Grado == 7 )
            {
                dias = new string[] { "V", "L", "K", "J", "M" };

            }
            bool espacioEncontrado = false;
            int i = 0;

            while (espacioEncontrado == false && i <= 4)
            {
                if (horario.EMateria.NombreMateria == "Contabilidad" || horario.EMateria.NombreMateria == "Computacion" && horario.EGrupo.Grado > 9)
                {
                    if (aDHorarios.obtenerTablaHorarios($" idMateria = { horario.EMateria.IdMateria } and idGrupo = { horario.EGrupo.IdGrupo} and dia = '{ dias[i]}' ").Tables[0].Rows.Count < 4  )
                    {
                        horario.Dia = dias[i];
                        espacioEncontrado = recorrerLecciones(cantidadMinimaLecciones, horario, tipoAula);
                        i++;
                    }
                    else
                    {
                        i++;
                    }
                }
                else
                {
                    horario.Dia = dias[i];
                    espacioEncontrado = recorrerLecciones(cantidadMinimaLecciones, horario, tipoAula);
                    i++;
                }

            }
            return espacioEncontrado;
        }

        /// <summary>
        /// Método que reccore las lecciones por horario para mandar a buscar espacio.  Recibe cantidad minima de lecciones, clase horario y tipo aula.
        /// </summary>
        /// <param name="cantidadMinimaLecciones"></param>
        /// <param name="horario"></param>
        /// <param name="tipoAula"></param>
        /// <returns></returns>
        private bool recorrerLecciones(int cantidadMinimaLecciones, EHorario horario, string tipoAula)
        {
            string[,] lecciones;
            if (horario.EGrupo.Grado >= 9 || (horario.EGrupo.Grado == 7 && horario.EGrupo.Seccion == 1)
                || (horario.EGrupo.Grado == 7 && horario.EGrupo.Seccion == 2) || (horario.EGrupo.Grado == 7 && horario.EGrupo.Seccion == 3) )
            {
                lecciones = new string[10, 2]
                {
                    { "07:20", "08:00" },
                    { "08:00", "08:40" },
                    { "09:00", "09:40" },
                    { "09:40", "10:20" },
                    { "10:40", "11:20" },
                    { "11:20", "12:00" },
                    { "13:00", "13:40" },
                    { "13:40", "14:20" },
                    { "14:40", "15:20" },
                    { "15:20", "16:00" },
                };
            }
            else
            {
                lecciones = new string[10, 2]
                {
                    { "14:40", "15:20" },
                    { "15:20", "16:00" },
                    { "13:00", "13:40" },
                    { "13:40", "14:20" },
                    { "10:40", "11:20" },
                    { "11:20", "12:00" },
                    { "09:00", "09:40" },
                    { "09:40", "10:20" },
                    { "07:20", "08:00" },
                    { "08:00", "08:40" },
                };
            }
           
            bool espacioEncontrado = false;
            int i = 0;

            while (espacioEncontrado == false && i <= 9)
            {
                // Validación del aula.
                switch (cantidadMinimaLecciones)
                {
                    case 2:
                        if (i <= 8)
                        {
                            if (revisarSiGrupoEstaLibre(horario, lecciones[i, 0], lecciones[i, 1]))
                            {
                                if (revisarSiGrupoEstaLibre(horario, lecciones[i+1, 0], lecciones[i+1, 1]))
                                {
                                    espacioEncontrado = validarAula(horario, lecciones[i, 0], lecciones[i, 1], lecciones[i + 1, 0], lecciones[i + 1, 1], tipoAula);
                                }
                            }                             
                        }
                        break;
                    case 1:
                        if (revisarSiGrupoEstaLibre(horario, lecciones[i, 0], lecciones[i, 1]))
                        {
                            espacioEncontrado = validarAula(horario, lecciones[i, 0], lecciones[i, 1], tipoAula);
                        }

                        break;
                    case 4:
                        if (i < 7)
                        {
                            espacioEncontrado = validarEspecialidad(horario, lecciones[i, 0], lecciones[i, 1], lecciones[i + 1, 0], lecciones[i + 1, 1],
                            lecciones[i + 2, 0], lecciones[i + 2, 1], lecciones[i + 3, 0], lecciones[i + 3, 1], tipoAula);

                            if (espacioEncontrado == false)
                            {
                                if (revisarSiGrupoEstaLibre(horario, lecciones[i, 0], lecciones[i, 1]))
                                {
                                    if (revisarSiGrupoEstaLibre(horario, lecciones[i+1, 0], lecciones[i+1, 1]))
                                    {
                                        if (revisarSiGrupoEstaLibre(horario, lecciones[i+2, 0], lecciones[i+2, 1]))
                                        {
                                            if (revisarSiGrupoEstaLibre(horario, lecciones[i+3, 0], lecciones[i+3, 1]))
                                            {
                                                espacioEncontrado = validarAula(horario, lecciones[i, 0], lecciones[i, 1], lecciones[i + 1, 0], lecciones[i + 1, 1],
                                                lecciones[i + 2, 0], lecciones[i + 2, 1], lecciones[i + 3, 0], lecciones[i + 3, 1],
                                                tipoAula);
                                            }
                                        }
                                    }
                                }

                            }                                                                                                     
                            
                        }
                        else
                        {
                            espacioEncontrado = false;

                        }

                        break;
                    default:
                        break;
                }
                i++;
            }

            return espacioEncontrado;
        }

        /// <summary>
        /// Método que revisa si el grupo esta libre en una leccion en especifico. Recibe clase horario, horaInicio, horaFinal.
        /// </summary>
        /// <param name="horario"></param>
        /// <param name="leccionIncio"></param>
        /// <param name="leccionFinal"></param>
        /// <returns>Bool</returns>
        private bool revisarSiGrupoEstaLibre(EHorario horario, string leccionIncio, string leccionFinal)
        {
            bool retorno = false;
            string condicion = $" idGrupo = {horario.EGrupo.IdGrupo} AND horaInicio = '{leccionIncio}' AND horaFin = '{leccionFinal}' AND dia = '{horario.Dia}'";
            if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Método que valida si un grupo ya tiene una especilidad A, para ser asignada la especialidad B . Recibe por 4 lecciones (hora inicio y final) y una clase horario.
        /// </summary>
        /// <param name="horario"></param>
        /// <param name="leccion1Inicio"></param>
        /// <param name="leccion1Final"></param>
        /// <param name="leccion2Inicio"></param>
        /// <param name="leccion2Final"></param>
        /// <param name="leccion3Inicio"></param>
        /// <param name="leccion3Final"></param>
        /// <param name="leccion4Inicio"></param>
        /// <param name="leccion4Final"></param>
        /// <param name="tipoAula"></param>
        /// <returns></returns>
        private bool validarEspecialidad(EHorario horario, string leccion1Inicio, string leccion1Final, string leccion2Inicio, string leccion2Final,
             string leccion3Inicio, string leccion3Final, string leccion4Inicio, string leccion4Final, string tipoAula)
        {
            bool espacioEncontrado = false;
            int idMateria;
            if (horario.EMateria.NombreMateria == "Contabilidad")
            {
                string condicion = $" nombreMateria = 'Computacion' ";
                idMateria = aDHorarios.listarMaterias(condicion)[0].IdMateria;
                condicion = $" idMateria = {idMateria} AND idGrupo = {horario.EGrupo.IdGrupo} ";
                if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count > 0)
                {
                    condicion = $" idMateria = {idMateria} AND horaInicio = '{leccion1Inicio}' AND horaFin = '{leccion1Final}' AND dia = '{horario.Dia}' AND idGrupo = '{horario.EGrupo.IdGrupo}'";
                    if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 1)
                    {
                        condicion = $" idMateria = {idMateria} AND horaInicio = '{leccion2Inicio}' AND horaFin = '{leccion2Final}' AND dia = '{horario.Dia}' AND idGrupo = '{horario.EGrupo.IdGrupo}'";
                        if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 1)
                        {
                            condicion = $" idMateria = {idMateria} AND horaInicio = '{leccion3Inicio}' AND horaFin = '{leccion3Final}' AND dia = '{horario.Dia}' AND idGrupo = '{horario.EGrupo.IdGrupo}'";
                            if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 1)
                            {
                                condicion = $" idMateria = {idMateria} AND horaInicio = '{leccion4Inicio}' AND horaFin = '{leccion4Final}' AND dia = '{horario.Dia}' AND idGrupo = '{horario.EGrupo.IdGrupo}'";
                                if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 1)
                                {
                                    condicion = $" idMateria = {horario.EMateria.IdMateria} AND horaInicio = '{leccion1Inicio}' AND horaFin = '{leccion1Final}' AND dia = '{horario.Dia}' AND idGrupo = '{horario.EGrupo.IdGrupo}'";
                                    if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
                                    {
                                        condicion = $" idMateria = {horario.EMateria.IdMateria} AND horaInicio = '{leccion2Inicio}' AND horaFin = '{leccion2Final}' AND dia = '{horario.Dia}' AND idGrupo = '{horario.EGrupo.IdGrupo}'";
                                        if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
                                        {
                                            validarAula(horario, leccion1Inicio, leccion1Final, leccion2Inicio, leccion2Final, leccion3Inicio, leccion3Final, leccion4Inicio, leccion4Final, tipoAula);
                                            espacioEncontrado = true;
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
            else
            {
                string condicion = $" nombreMateria = 'Contabilidad' ";

                idMateria = aDHorarios.listarMaterias(condicion)[0].IdMateria;

                condicion = $" idMateria = {idMateria} AND idGrupo = {horario.EGrupo.IdGrupo} ";
                if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count > 0)
                {
                    if (revisarSiMateriaEstaLibre(idMateria,leccion1Inicio, leccion1Final, horario.Dia, 1, horario.EGrupo.IdGrupo))
                    {
                        if (revisarSiMateriaEstaLibre(idMateria, leccion2Inicio, leccion2Final, horario.Dia, 1, horario.EGrupo.IdGrupo))
                        {
                            if (revisarSiMateriaEstaLibre(idMateria, leccion3Inicio, leccion3Final, horario.Dia, 1, horario.EGrupo.IdGrupo))
                            {
                                if (revisarSiMateriaEstaLibre(idMateria, leccion4Inicio, leccion4Final, horario.Dia, 1, horario.EGrupo.IdGrupo))
                                {
                                    if (revisarSiMateriaEstaLibre(idMateria, leccion4Inicio, leccion4Final, horario.Dia, 1, horario.EGrupo.IdGrupo))
                                    {
                                        condicion = $" idMateria = {horario.EMateria.IdMateria} AND horaInicio = '{leccion1Inicio}' AND horaFin = '{leccion1Final}' AND dia = '{horario.Dia}' AND idGrupo = '{horario.EGrupo.IdGrupo}'";
                                        if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
                                        {
                                            condicion = $" idMateria = {horario.EMateria.IdMateria} AND horaInicio = '{leccion2Inicio}' AND horaFin = '{leccion2Final}' AND dia = '{horario.Dia}' AND idGrupo = '{horario.EGrupo.IdGrupo}'";
                                            if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
                                            {
                                                validarAula(horario, leccion1Inicio, leccion1Final, leccion2Inicio, leccion2Final, leccion3Inicio, leccion3Final, leccion4Inicio, leccion4Final, tipoAula);
                                                espacioEncontrado = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }                                                 
                }
            }



            return espacioEncontrado;
        }

        /// <summary>
        /// Método que revisa si el grupo esta libre en una leccion en especifico. Recibe clase horario, horaInicio, horaFinal.
        /// </summary>
        /// <param name="horario"></param>
        /// <param name="leccionIncio"></param>
        /// <param name="leccionFinal"></param>
        /// <returns>Bool</returns>
        private bool revisarSiMateriaEstaLibre(int idMateria, string leccionIncio, string leccionFinal, string dia, int cantidad, int idGrupo)
        {
            bool retorno = false;
            string condicion = $" idMateria = {idMateria} AND horaInicio = '{leccionIncio}' AND horaFin = '{leccionFinal}' AND dia = '{dia}' AND idGrupo = '{idGrupo}'";
            if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == cantidad)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Método que valida si un aula esta libre. Recibe el idAula, y leccion (hora inicio y final, y el día)
        /// </summary>
        /// <param name="horario"></param>
        /// <param name="leccion1Inicio"></param>
        /// <param name="leccion1Final"></param>
        /// <param name="leccion2Inicio"></param>
        /// <param name="leccion2Final"></param>
        /// <param name="tipoAula"></param>
        /// <returns>Bool</returns>
        private bool revisarSiAulaEstaLibre(int idAula, string leccionIncio, string leccionFinal, string dia)
        {
            bool retorno = false;
            string condicion = $" idAula = {idAula} AND horaInicio = '{leccionIncio}' AND horaFin = '{leccionFinal}' AND dia = '{dia}'";
            if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Método que valida si las aulas están vacidas en las lecciones solicitadas. Recibe por parámetros dos lecciones (hora inicio y final), y tipo de aula.
        /// </summary>
        /// <param name="horario"></param>
        /// <param name="leccion1Inicio"></param>
        /// <param name="leccion1Final"></param>
        /// <param name="leccion2Inicio"></param>
        /// <param name="leccion2Final"></param>
        /// <param name="tipoAula"></param>
        /// <returns></returns>
        private bool validarAula(EHorario horario, string leccion1Inicio, string leccion1Final, string leccion2Inicio, string leccion2Final, string tipoAula)
        {
            bool espacioEncontrado = false;
            int i = 0;

            while (espacioEncontrado == false && i < listaAulas.Count)
            {
                string condicion = $" and idAula = {listaAulas[i].IdAula} AND tipoAula = '{tipoAula}'";
                if (aDHorarios.listarAulas(condicion).Count == 1)
                {
                    if (revisarSiAulaEstaLibre(listaAulas[i].IdAula, leccion1Inicio, leccion1Final, horario.Dia))
                    {
                        if (revisarSiAulaEstaLibre(listaAulas[i].IdAula, leccion2Inicio, leccion2Final, horario.Dia))
                        {
                            horario.EAula = listaAulas[i];
                            espacioEncontrado = buscarProfesor(horario, leccion1Inicio, leccion1Final, leccion2Inicio, leccion2Final);
                        }
                    }                     
                }
                i++;
            }
            return espacioEncontrado;
        }

        /// <summary>
        /// Método que valida si las aulas están vacidas en las lecciones solicitadas. Recibe por parámetros 4 lecciones (hora inicio y final), y tipo de aula.
        /// </summary>
        /// <param name="horario"></param>
        /// <param name="leccion1Inicio"></param>
        /// <param name="leccion1Final"></param>
        /// <param name="leccion2Inicio"></param>
        /// <param name="leccion2Final"></param>
        /// <param name="tipoAula"></param>
        /// <returns></returns>
        private bool validarAula(EHorario horario, string leccion1Inicio, string leccion1Final, string leccion2Inicio, string leccion2Final,
             string leccion3Inicio, string leccion3Final, string leccion4Inicio, string leccion4Final, string tipoAula)
        {
            bool espacioEncontrado = false;
            int i = 0;

            while (espacioEncontrado == false && i < listaAulas.Count)
            {
                string condicion = $" and idAula = {listaAulas[i].IdAula} AND tipoAula = '{tipoAula}'";
                if (aDHorarios.listarAulas(condicion).Count == 1)
                {
                    if (revisarSiAulaEstaLibre(listaAulas[i].IdAula, leccion1Inicio, leccion1Final, horario.Dia))
                    {
                        if (revisarSiAulaEstaLibre(listaAulas[i].IdAula, leccion2Inicio, leccion2Final, horario.Dia))
                        {
                            if (revisarSiAulaEstaLibre(listaAulas[i].IdAula, leccion3Inicio, leccion3Final, horario.Dia))
                            {
                                if (revisarSiAulaEstaLibre(listaAulas[i].IdAula, leccion4Inicio, leccion4Final, horario.Dia))
                                {
                                    horario.EAula = listaAulas[i];
                                    espacioEncontrado = buscarProfesor(horario, leccion1Inicio, leccion1Final, leccion2Inicio, leccion2Final,
                                          leccion3Inicio, leccion3Final, leccion4Inicio, leccion4Final);
                                }
                            }
                        }
                    }
                }
                i++;
            }
            return espacioEncontrado;   
        }

        /// <summary>
        /// Método que valida si las aulas están vacidas en las lecciones solicitadas. Recibe por parámetros 1 lecciones (hora inicio y final), y tipo de aula.
        /// </summary>
        /// <param name="horario"></param>
        /// <param name="leccion1Inicio"></param>
        /// <param name="leccion1Final"></param>
        /// <param name="tipoAula"></param>
        /// <returns></returns>
        private bool validarAula(EHorario horario, string leccion1Inicio, string leccion1Final, string tipoAula)
        {
            bool espacioEncontrado = false;
            int i = 0;

            while (espacioEncontrado == false && i < listaAulas.Count)
            {
                string condicion = $" idAula = {listaAulas[i].IdAula} AND horaInicio = '{leccion1Inicio}' AND horaFin = '{leccion1Final}' AND dia = '{horario.Dia}'";
                if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
                {
                    condicion = $" and idAula = {listaAulas[i].IdAula} AND tipoAula = '{tipoAula}'";

                    if (aDHorarios.listarAulas(condicion).Count == 1)
                    {
                        horario.EAula = listaAulas[i];
                        espacioEncontrado = buscarProfesor(horario, leccion1Inicio, leccion1Final);
                        ;
                    }
                }
                i++;
            }

            return espacioEncontrado;
        }

        /// <summary>
        /// Metodo que revisa si el profesor esta libre. Recibe el id profesor, una leccion (hora inicio y final).
        /// </summary>
        /// <param name="idProfesor"></param>
        /// <param name="leccionIncio"></param>
        /// <param name="leccionFinal"></param>
        /// <param name="dia"></param>
        /// <returns>Bool</returns>
        private bool revisarSiProfeEstaLibre(int idProfesor, string leccionIncio, string leccionFinal, string dia)
        {
            bool retorno = false;
            string condicion = $" idProfesor = {idProfesor} AND horaInicio = '{leccionIncio}' AND horaFin = '{leccionFinal}' AND dia = '{dia}'";
            if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Metodo que revisa y asigna un profesor si esta libre. Recibe por parámetro dos lecciones (incio y final), y clase horario.
        /// </summary>
        /// <param name="horario"></param>
        /// <param name="leccion1Inicio"></param>
        /// <param name="leccion1Final"></param>
        /// <param name="leccion2Inicio"></param>
        /// <param name="leccion2Final"></param>
        /// <returns></returns>
        private bool buscarProfesor(EHorario horario, string leccion1Inicio, string leccion1Final, string leccion2Inicio, string leccion2Final)
        {
            bool espacioEncontrado = false;
            int i = 0;
            horario.EProfesor = aDHorarios.devolverProfesorPorGrupo($" h.idGrupo = {horario.EGrupo.IdGrupo} and h.idMateria = {horario.EMateria.IdMateria} ");
            // Si el profesor cuenta con las cantidad de horas necesarias para dar las lecciones que corresponde a dicha ma
            if (horario.EProfesor.Nombre != null)
            {
                // Valida que el profesor este libre en la leccion 1.
                if (revisarSiProfeEstaLibre(listaProfesores[i].Id, leccion1Inicio, leccion1Final, horario.Dia))
                {
                    if (revisarSiProfeEstaLibre(listaProfesores[i].Id, leccion2Inicio, leccion2Final, horario.Dia))
                    {
                        if (aDHorarios.obtenerLeccionesProfesor(listaProfesores[i]) <= 40)
                        {
                            horario.HoraInicio = leccion1Inicio;
                            horario.HoraFinal = leccion1Final;
                            aDHorarios.insertarHorario(horario);
                            horario.HoraInicio = leccion2Inicio;
                            horario.HoraFinal = leccion2Final;
                            aDHorarios.insertarHorario(horario);
                            espacioEncontrado = true;
                        }
                        else
                        {
                            espacioEncontrado = false;
                        }
                    }
                }

            }
            else
            {
                while (espacioEncontrado == false && i < listaProfesores.Count)
                {
                    // Valida si el profesor es de esa materia
                    string condicion = $" idProfesor = '{listaProfesores[i].Id}' AND idMateria = '{horario.EMateria.IdMateria}'";
                    if (aDHorarios.listarProfesores(condicion).Count > 0)
                    {
                        // Valida que un profesor pueda dar la clases necesarias a un grupo en especial previniendo que un grupo tenga dos profesores por materia.
                        int cantidadLeccionesAsignadas = aDHorarios.obtenerLeccionesProfesor(listaProfesores[i]);
                        if (cantidadLeccionesAsignadas + cantidadLeccionesRequeridas <= 40)
                        {
                            // Valida que el profesor este libre en la leccion 1.
                            if (revisarSiProfeEstaLibre(listaProfesores[i].Id, leccion1Inicio, leccion1Final, horario.Dia))
                            {
                                if (revisarSiProfeEstaLibre(listaProfesores[i].Id, leccion2Inicio, leccion2Final, horario.Dia))
                                {
                                    if (aDHorarios.obtenerLeccionesProfesor(listaProfesores[i]) <= 40)
                                    {
                                        horario.EProfesor = listaProfesores[i];
                                        horario.HoraInicio = leccion1Inicio;
                                        horario.HoraFinal = leccion1Final;
                                        aDHorarios.insertarHorario(horario);
                                        horario.HoraInicio = leccion2Inicio;
                                        horario.HoraFinal = leccion2Final;
                                        aDHorarios.insertarHorario(horario);
                                        espacioEncontrado = true;
                                    }
                                    else
                                    {
                                        espacioEncontrado = false;
                                    }
                                }
                            }
                        }

                    }
                    i++;
                }
            }

            return espacioEncontrado;
        }

        /// <summary>
        /// Metodo que revisa y asigna un profesor si esta libre. Recibe por parámetro 1 leccion (incio y final), y clase horario.
        /// </summary>
        /// <param name="horario"></param>
        /// <param name="leccion1Inicio"></param>
        /// <param name="leccion1Final"></param>
        /// <param name="leccion2Inicio"></param>
        /// <param name="leccion2Final"></param>
        /// <returns></returns>
        private bool buscarProfesor(EHorario horario, string leccion1Inicio, string leccion1Final)
        {
            bool espacioEncontrado = false;
            int i = 0;

            horario.EProfesor = aDHorarios.devolverProfesorPorGrupo( $" h.idGrupo = {horario.EGrupo.IdGrupo} and h.idMateria = {horario.EMateria.IdMateria} ");
            // Si el profesor cuenta con las cantidad de horas necesarias para dar las lecciones que corresponde a dicha ma
            if (horario.EProfesor.Nombre != null)
            {
                if (revisarSiProfeEstaLibre(listaProfesores[i].Id, leccion1Inicio, leccion1Final, horario.Dia))
                {
                    int cantidadLeccionesAsignadas = aDHorarios.obtenerLeccionesProfesor(listaProfesores[i]);
                    if (cantidadLeccionesAsignadas <= 40)
                    {
                        horario.HoraInicio = leccion1Inicio;
                        horario.HoraFinal = leccion1Final;
                        aDHorarios.insertarHorario(horario);
                        espacioEncontrado = true;
                    }
                    else
                    {
                        espacioEncontrado = false;
                    }
                }
            }
            else
            {
                while (espacioEncontrado == false && i < listaProfesores.Count)
                {
                    // Valida si el profesor es de esa materia
                    string condicion = $" idProfesor = '{listaProfesores[i].Id}' AND idMateria = '{horario.EMateria.IdMateria}'";
                    if (aDHorarios.listarProfesores(condicion).Count > 0)
                    {
                        // Valida que un profesor pueda dar la clases necesarias a un grupo en especial previniendo que un grupo tenga dos profesores por materia.
                        int cantidadLeccionesAsignadas = aDHorarios.obtenerLeccionesProfesor(listaProfesores[i]);
                        if (cantidadLeccionesAsignadas + cantidadLeccionesRequeridas <= 40)
                        {
                            if (revisarSiProfeEstaLibre(listaProfesores[i].Id, leccion1Inicio, leccion1Final, horario.Dia))
                            {
                                if (cantidadLeccionesAsignadas <= 40)
                                {
                                    horario.EProfesor = listaProfesores[i];
                                    horario.HoraInicio = leccion1Inicio;
                                    horario.HoraFinal = leccion1Final;
                                    aDHorarios.insertarHorario(horario);
                                    espacioEncontrado = true;
                                }
                                else
                                {
                                    espacioEncontrado = false;
                                }
                            }
                        }

                    }
                    i++;
                }
            }
            return espacioEncontrado;
        }


        /// <summary>
        /// Metodo que revisa y asigna un profesor si esta libre. Recibe por parámetro 4 lecciones (incio y final), y clase horario.
        /// </summary>
        /// <param name="horario"></param>
        /// <param name="leccion1Inicio"></param>
        /// <param name="leccion1Final"></param>
        /// <param name="leccion2Inicio"></param>
        /// <param name="leccion2Final"></param>
        /// <param name="leccion3Inicio"></param>
        /// <param name="leccion3Final"></param>
        /// <param name="leccion4Inicio"></param>
        /// <param name="leccion4Final"></param>
        /// <returns></returns>
        private bool buscarProfesor(EHorario horario, string leccion1Inicio, string leccion1Final, string leccion2Inicio, string leccion2Final,
             string leccion3Inicio, string leccion3Final, string leccion4Inicio, string leccion4Final)
        {
            bool espacioEncontrado = false;
            int i = 0;

            horario.EProfesor = aDHorarios.devolverProfesorPorGrupo($" h.idGrupo = {horario.EGrupo.IdGrupo} and h.idMateria = {horario.EMateria.IdMateria} ");
            // Si el profesor cuenta con las cantidad de horas necesarias para dar las lecciones que corresponde a dicha ma
            if (horario.EProfesor.Nombre != null)
            {
                if (revisarSiProfeEstaLibre(listaProfesores[i].Id, leccion1Inicio, leccion1Final, horario.Dia))
                {
                    if (revisarSiProfeEstaLibre(listaProfesores[i].Id, leccion2Inicio, leccion2Final, horario.Dia))
                    {
                        if (revisarSiProfeEstaLibre(listaProfesores[i].Id, leccion3Inicio, leccion3Final, horario.Dia))
                        {
                            if (revisarSiProfeEstaLibre(listaProfesores[i].Id, leccion4Inicio, leccion4Final, horario.Dia))
                            {
                                horario.HoraInicio = leccion1Inicio;
                                horario.HoraFinal = leccion1Final;
                                aDHorarios.insertarHorario(horario);
                                horario.HoraInicio = leccion2Inicio;
                                horario.HoraFinal = leccion2Final;
                                aDHorarios.insertarHorario(horario);
                                horario.HoraInicio = leccion3Inicio;
                                horario.HoraFinal = leccion3Final;
                                aDHorarios.insertarHorario(horario);
                                horario.HoraInicio = leccion4Inicio;
                                horario.HoraFinal = leccion4Final;
                                aDHorarios.insertarHorario(horario);
                                espacioEncontrado = true;
                            }
                        }
                    }
                }


            }
            else
            {
                while (espacioEncontrado == false && i < listaProfesores.Count)
                {
                    // Valida si el profesor es de esa materia
                    string condicion = $" idProfesor = '{listaProfesores[i].Id}' AND idMateria = '{horario.EMateria.IdMateria}'";
                    if (aDHorarios.listarProfesores(condicion).Count > 0)
                    {
                        // Valida que un profesor pueda dar la clases necesarias a un grupo en especial previniendo que un grupo tenga dos profesores por materia.
                        int cantidadLeccionesAsignadas = aDHorarios.obtenerLeccionesProfesor(listaProfesores[i]);
                        if (cantidadLeccionesAsignadas + cantidadLeccionesRequeridas <= 40)
                        {
                            if (revisarSiProfeEstaLibre(listaProfesores[i].Id, leccion1Inicio, leccion1Final, horario.Dia))
                            {
                                if (revisarSiProfeEstaLibre(listaProfesores[i].Id, leccion2Inicio, leccion2Final, horario.Dia))
                                {
                                    if (revisarSiProfeEstaLibre(listaProfesores[i].Id, leccion3Inicio, leccion3Final, horario.Dia))
                                    {
                                        if (revisarSiProfeEstaLibre(listaProfesores[i].Id, leccion4Inicio, leccion4Final, horario.Dia))
                                        {
                                            if (cantidadLeccionesAsignadas <= 40)
                                            {
                                                horario.EProfesor = listaProfesores[i];
                                                horario.HoraInicio = leccion1Inicio;
                                                horario.HoraFinal = leccion1Final;
                                                aDHorarios.insertarHorario(horario);
                                                horario.HoraInicio = leccion2Inicio;
                                                horario.HoraFinal = leccion2Final;
                                                aDHorarios.insertarHorario(horario);
                                                horario.HoraInicio = leccion3Inicio;
                                                horario.HoraFinal = leccion3Final;
                                                aDHorarios.insertarHorario(horario);
                                                horario.HoraInicio = leccion4Inicio;
                                                horario.HoraFinal = leccion4Final;
                                                aDHorarios.insertarHorario(horario);
                                                espacioEncontrado = true;
                                            }
                                            else
                                            {
                                                espacioEncontrado = false;
                                            }

                                        }
                                    }
                                }
                            }
                        }

                    }
                    i++;



                }
            }

            return espacioEncontrado;
        }

        /// <summary>
        /// Metodo que retorna una lista con el horario de un dia. Recibe el grado, seccion, año, y una condicion alternativa.
        /// </summary>
        /// <param name="grado"></param>
        /// <param name="seccion"></param>
        /// <param name="anio"></param>
        /// <param name="dia"></param>
        /// <param name="condicion2"></param>
        /// <returns>Lista string con horario de un dia</returns>
        public List<string> listaHorario(int grado, int seccion, int anio, string dia, string condicion2 = "")
        {
            List<string> listaHorarios = new List<string>();

            string[,] lecciones;
            lecciones = new string[10, 2]
            {
                { "07:20", "08:00" },
                { "08:00", "08:40" },
                { "09:00", "09:40" },
                { "09:40", "10:20" },
                { "10:40", "11:20" },
                { "11:20", "12:00" },
                { "13:00", "13:40" },
                { "13:40", "14:20" },
                { "14:40", "15:20" },
                { "15:20", "16:00" },
            };

            for (int i = 0; i < 10; i++)
            {
                EHorario eHorario = new EHorario();
                string condicion = $" g.grado= {grado} and g.seccion = {seccion} AND h.horaInicio = '{lecciones[i,0]}' AND h.horaFin = '{lecciones[i, 1]}' AND h.dia = '{dia}' AND g.anio = {anio} ";
                if (condicion2 !="")
                {
                    condicion = string.Format("{0} {1}", condicion, condicion2);
                }
                eHorario = aDHorarios.devolverHorario(condicion);

                if (eHorario.ToString() != "Lección libre")
                {
                    listaHorarios.Add(" Aula:" + eHorario.EAula.CodigoAula);
                    listaHorarios.Add(" Profesor:" + eHorario.EProfesor.Nombre + " " + eHorario.EProfesor.Apellido1);
                    listaHorarios.Add(" Materia: " + eHorario.EMateria.NombreMateria);
                }
                else
                {
                    listaHorarios.Add(" ");
                    listaHorarios.Add(" ");
                    listaHorarios.Add(" ");
                }
                switch (i)
                {
                    case 1:
                    case 3:
                    case 7:
                        listaHorarios.Add(" Recreo");
                        break;
                    case 5:
                        listaHorarios.Add(" Almuerzo");
                        break;
                }

            }


        EHorario horario = new EHorario();

        return listaHorarios;
        }

        /// <summary>
        /// Metodo que retorna las lista de los grupo. Recibe un condicion alternativa.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Lista string</returns>
        public List<EGrupo> listarGrupos(string condicion = "")
        {
            List<EGrupo> listaGrupos;

            try
            {
                listaGrupos = aDHorarios.listarGrupos(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listaGrupos;
        }

        /// <summary>
        /// Metodo que retorna un data set con los horarios. Recibe un condicion alternativa.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Data set</returns>
        public DataSet obtenerTablaHorarios(string condicion = "")
        {
            DataSet setHorario;
            try
            {
                setHorario = aDHorarios.obtenerTablaHorarios(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return setHorario;
        }

        /// <summary>
        /// Metodo que retorna las lista de los materias. Recibe un condicion alternativa.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Lista clase materia</returns>
        public List<EMateria> listarMaterias(string condicion = "")
        {
            List<EMateria> listaM ;

            try
            {
                listaM = aDHorarios.listarMaterias(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listaM;
        }

        /// <summary>
        /// Metodo que retorna las lista de los profesores. Recibe un condicion alternativa.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Lista profesores</returns>
        public List<EProfesor> listarProfesores(string condicion = "")
        {
            List<EProfesor> listaP;

            try
            {
                listaP = aDHorarios.listarProfesores(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listaP;
        }

        /// <summary>
        /// Metodo que retorna las lista de las aulas. Recibe un condicion alternativa.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Lista aulas</returns>
        public List<EAula> listarAulas(string condicion = "")
        {
            List<EAula> listaA;

            try
            {
                listaA = aDHorarios.listarAulas(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listaA;
        }

        public string eliminarProcedure(EHorario horario)
        {

            string mensaje = "";

            try
            {
                mensaje = aDHorarios.eliminarProcedure(horario);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return mensaje;
        }
    }
}
