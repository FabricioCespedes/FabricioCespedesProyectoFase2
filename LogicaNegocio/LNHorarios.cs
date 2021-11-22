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
        int contador;
        /// <summary>
        /// Constructor de la lógica de negocio de laclase Horarios. Recibe 
        /// </summary>
        /// <param name="cadConexion"></param>
        public LNHorarios(string cadConexion)
        {
            this.cadConexion = cadConexion;
            aDHorarios = new ADHorarios(cadConexion);
            listaGrupos = aDHorarios.listarGrupos();
            listaProfesores = aDHorarios.listarProfesores();
            listaAulas = aDHorarios.listarAulas();
        }

        public string  procesoCrearHorarios()
        {
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
            return "Completado";
        }

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

        private void buscarLeccionesVacias(int cantidadLecciones, EHorario horario, int cantidadMinimaLecciones, string tipoAula)
        {
            bool campoLeccionEncontrado = false;
            while (cantidadLecciones > 0)
            {
                campoLeccionEncontrado =  recorrerDias(cantidadMinimaLecciones, horario, tipoAula);

                if (campoLeccionEncontrado) cantidadLecciones = cantidadLecciones - cantidadMinimaLecciones;

            }
        }

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
            bool espacioEncontrado = false;
            int i = 0;

            while (espacioEncontrado == false && i <= 4)
            {
                horario.Dia = dias[i];
                espacioEncontrado = recorrerLecciones(cantidadMinimaLecciones, horario, tipoAula);
                i++;
            }
            return espacioEncontrado;
        }

        private bool recorrerLecciones(int cantidadMinimaLecciones, EHorario horario, string tipoAula)
        {
            string condicion;
            string[,] lecciones;
            if (horario.EGrupo.Grado >= 9 || (horario.EGrupo.Grado == 7 && horario.EGrupo.Seccion == 1)


                || (horario.EGrupo.Grado == 7 && horario.EGrupo.Seccion == 2) 


                || (horario.EGrupo.Grado == 7 && horario.EGrupo.Seccion == 3) )
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
                            condicion = $" idGrupo = '{horario.EGrupo.IdGrupo}' AND horaInicio = '{lecciones[i, 0]}' AND horaFin = '{lecciones[i, 1]}' AND dia = '{horario.Dia}'";

                            if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
                            {
                                condicion = $" idGrupo = '{horario.EGrupo.IdGrupo}' AND horaInicio = '{lecciones[i + 1, 0]}' AND horaFin = '{lecciones[i + 1, 1]}' AND dia = '{horario.Dia}'";

                                if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
                                {

                                    espacioEncontrado = validarAula(horario, lecciones[i, 0], lecciones[i, 1], lecciones[i + 1, 0], lecciones[i + 1, 1], tipoAula);

                                }
                            }
                        }
                        break;
                    case 1:
                         condicion = $" idGrupo = '{horario.EGrupo.IdGrupo}' AND horaInicio = '{lecciones[i, 0]}' AND horaFin = '{lecciones[i, 1]}' AND dia = '{horario.Dia}'";

                        if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
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
                                // Validar que el grupo este libre en las lecciones designadas.
                                condicion = $" idGrupo = '{horario.EGrupo.IdGrupo}' AND horaInicio = '{lecciones[i, 0]}' AND horaFin = '{lecciones[i, 1]}' AND dia = '{horario.Dia}'";

                                if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
                                {
                                    condicion = $" idGrupo = '{horario.EGrupo.IdGrupo}' AND horaInicio = '{lecciones[i + 1, 0]}' AND horaFin = '{lecciones[i + 1, 1]}' AND dia = '{horario.Dia}'";

                                    if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
                                    {
                                        condicion = $" idGrupo = '{horario.EGrupo.IdGrupo}' AND horaInicio = '{lecciones[i + 2, 0]}' AND horaFin = '{lecciones[i + 2, 1]}' AND dia = '{horario.Dia}'";
                                        if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
                                        {
                                            condicion = $" idGrupo = '{horario.EGrupo.IdGrupo}' AND horaInicio = '{lecciones[i + 3, 0]}' AND horaFin = '{lecciones[i + 3, 1]}' AND dia = '{horario.Dia}'";

                                            if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
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



            return espacioEncontrado;
        }

        private bool validarAula(EHorario horario, string leccion1Inicio, string leccion1Final, string leccion2Inicio, string leccion2Final, string tipoAula)
        {
            bool espacioEncontrado = false;
            int i = 0;

            while (espacioEncontrado == false && i < listaAulas.Count)
            {
                string condicion = $" idAula = {listaAulas[i].IdAula} AND horaInicio = '{leccion1Inicio}' AND horaFin = '{leccion1Final}' AND dia = '{horario.Dia}'";
                if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
                {
                    condicion = $" idAula = {listaAulas[i].IdAula} AND horaInicio = '{leccion2Inicio}' AND horaFin = '{leccion2Final}' AND dia = '{horario.Dia}'";
                    if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
                    {
                        condicion = $" and idAula = {listaAulas[i].IdAula} AND tipoAula = '{tipoAula}'";
                        if (aDHorarios.listarAulas(condicion).Count == 1)
                        {
                            horario.EAula = listaAulas[i];
                            espacioEncontrado = buscarProfesor(horario, leccion1Inicio, leccion1Final,leccion2Inicio,leccion2Final);
                            ;
                        }
                    }
                }
                i++;
            }

            return espacioEncontrado;
        }

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

                    condicion = $" idAula = {listaAulas[i].IdAula} AND horaInicio = '{leccion1Inicio}' AND horaFin = '{leccion1Final}' AND dia = '{horario.Dia}'";
                    if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
                    {
                        condicion = $" idAula = {listaAulas[i].IdAula} AND horaInicio = '{leccion2Inicio}' AND horaFin = '{leccion2Final}' AND dia = '{horario.Dia}'";
                        if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
                        {
                            condicion = $" idAula = {listaAulas[i].IdAula} AND horaInicio = '{leccion3Inicio}' AND horaFin = '{leccion3Final}' AND dia = '{horario.Dia}'";
                            if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
                            {
                                condicion = $" idAula = {listaAulas[i].IdAula} AND horaInicio = '{leccion4Inicio}' AND horaFin = '{leccion4Final}' AND dia = '{horario.Dia}'";
                                if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
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

        private bool buscarProfesor(EHorario horario, string leccion1Inicio, string leccion1Final, string leccion2Inicio, string leccion2Final)
        {
            bool espacioEncontrado = false;
            int i = 0;

            while (espacioEncontrado == false && i < listaProfesores.Count)
            {

                // Valida si el profesor es de esa materia
                string condicion = $" idProfesor = '{listaProfesores[i].Id}' AND idMateria = '{horario.EMateria.IdMateria}'";
                if (aDHorarios.listarProfesores(condicion).Count > 0)
                {
                    // Valida que el profesor este libre en la leccion 1.
                    condicion = $" idProfesor = '{listaProfesores[i].Id}' AND horaInicio = '{leccion1Inicio}' AND horaFin = '{leccion1Final}' AND dia = '{horario.Dia}' ";
                    if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
                    {
                        // Valida que el profesor este libre en la leccion 2.
                        condicion = $" idProfesor = '{listaProfesores[i].Id}' AND horaInicio = '{leccion2Inicio}' AND horaFin = '{leccion2Final}' AND dia = '{horario.Dia}'";
                        if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
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
                i++;
            }
            return espacioEncontrado;
        }

        private bool buscarProfesor(EHorario horario, string leccion1Inicio, string leccion1Final)
        {
            bool espacioEncontrado = false;
            int i = 0;

            while (espacioEncontrado == false && i < listaProfesores.Count)
            {

                // Valida si el profesor es de esa materia
                string condicion = $" idProfesor = '{listaProfesores[i].Id}' AND idMateria = '{horario.EMateria.IdMateria}'";
                if (aDHorarios.listarProfesores(condicion).Count > 0)
                {
                    // Valida que el profesor este libre en la leccion 1.
                    condicion = $" idProfesor = '{listaProfesores[i].Id}' AND horaInicio = '{leccion1Inicio}' AND horaFin = '{leccion1Final}' AND dia = '{horario.Dia}' ";
                    if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
                    {
                            if (aDHorarios.obtenerLeccionesProfesor(listaProfesores[i]) <= 40)
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
                i++;
            }
            return espacioEncontrado;
        }

        private bool buscarProfesor(EHorario horario, string leccion1Inicio, string leccion1Final, string leccion2Inicio, string leccion2Final,
             string leccion3Inicio, string leccion3Final, string leccion4Inicio, string leccion4Final)
        {
            bool espacioEncontrado = false;
            int i = 0;

            while (espacioEncontrado == false && i < listaProfesores.Count)
            {

                // Valida si el profesor es de esa materia
                string condicion = $" idProfesor = '{listaProfesores[i].Id}' AND idMateria = '{horario.EMateria.IdMateria}'";
                if (aDHorarios.listarProfesores(condicion).Count > 0)
                {
                    // Valida que el profesor este libre en la leccion 1.
                    condicion = $" idProfesor = '{listaProfesores[i].Id}' AND horaInicio = '{leccion1Inicio}' AND horaFin = '{leccion1Final}' AND dia = '{horario.Dia}' ";
                    if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
                    {
                        // Valida que el profesor este libre en la leccion 2.
                        condicion = $" idProfesor = '{listaProfesores[i].Id}' AND horaInicio = '{leccion2Inicio}' AND horaFin = '{leccion2Final}' AND dia = '{horario.Dia}'";
                        if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
                        {
                            // Valida que el profesor este libre en la leccion 3.
                            condicion = $" idProfesor = '{listaProfesores[i].Id}' AND horaInicio = '{leccion3Inicio}' AND horaFin = '{leccion3Final}' AND dia = '{horario.Dia}' ";
                            if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
                            {
                                // Valida que el profesor este libre en la leccion 4.
                                condicion = $" idProfesor = '{listaProfesores[i].Id}' AND horaInicio = '{leccion4Inicio}' AND horaFin = '{leccion4Final}' AND dia = '{horario.Dia}'";
                                if (aDHorarios.obtenerTablaHorarios(condicion).Tables[0].Rows.Count == 0)
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
                            }
                        }
                    }
                }
                i++;
            }
            return espacioEncontrado;
        }

        public EHorario devolverHorario(string condicion)
        {
            EHorario horario;

            ADHorarios aDHorarios = new ADHorarios(cadConexion);

            try
            {
                horario = aDHorarios.devolverHorario(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return horario;
        }


        public List<EHorario> listaHorario(int grado, int seccion, int anio, string dia, string condicion2 = "")
        {
            List<EHorario> listaHorarios = new List<EHorario>();

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
                if (condicion !="")
                {
                    condicion = string.Format("{0} {1}", condicion, condicion2);
                }

                if (aDHorarios.devolverHorario(condicion) != null)
                {
                    eHorario = aDHorarios.devolverHorario(condicion);
                }

                listaHorarios.Add(eHorario);
            }


        EHorario horario = new EHorario();

        return listaHorarios;
        }



        /*        public void ingresarLeccion()
        {          //EHorario horario
            try
            {
                if (Horarios == null)
                {
                    setHorarios = aDHorarios.obtenerTablaHorarios();
                    Horarios = setHorarios.Tables[0];
                }         
                //DataRow row = Horarios.NewRow();
                //row["idMateria"] = horario.EMateria.IdMateria;
                //row["idProfesor"] = horario.EProfesor.Id;
                //row["dia"] = horario.Dia;
                //row["horaInicio"] = horario.HoraInicio;
                //row["horaFin"] = horario.HoraFinal;
                //row["idAula"] = horario.EAula.IdAula;
                //row["idGrupo"] = horario.EGrupo.IdGrupo;
                //Horarios.Rows.Add(row);
                validarAula();
                aDHorarios.actualizarDataSet(setHorarios);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }*/
    }
}
