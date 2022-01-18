<%@ Page Title="" Language="C#" MasterPageFile="~/wfrmPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmRevisarSolicitudes.aspx.cs" Inherits="PresentacionWeb.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="card text-center">
            <h1 class="card-title">Revisar solicitudes</h1>
        </div>
        <%--Alert--%>
        <div>
            <%  if (Session["_exito"] != null)
                {%>
            <div class="alert alert-primary alert-dismissible fade show" role="alert">
                <strong><%= Session["_exito"].ToString()%> </strong>
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>

            <% Session["_exito"] = null;
                } %>            <%if (Session["_err"] != null)
                {%>
            <div class="alert alert-danger" role="alert">
                <% = Session["_err"].ToString()%>
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>

            <% }%>            <%if (Session["_wrn"] != null)
                {%>
            <div class="alert alert-warning" role="alert">
                <% = Session["_wrn"].ToString()%>
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>
            <% }%>
        </div>
        <%--AlertEND--%>
        <div style="display: flex; justify-content: center; align-items: center">
            <div class="container text-center card p-5  m-5" style="width: 100%;">
                <i class="fas fa-people-arrows fs-1"></i>
                <br />

                <div class="row ">
                    <asp:GridView CssClass="table table-borderedtable-striped table-hover m-1" Style="width: 100%;" ID="GridView1" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="idSolicitud" HeaderText="id" Visible="False" />
                            <asp:BoundField DataField="profe" HeaderText="Profesor" ItemStyle-HorizontalAlign="Justify" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Justify" Width="100px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="estudiante" HeaderText="Estudiante" ItemStyle-HorizontalAlign="Justify" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Justify" Width="100px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="trimestre" HeaderText="Trimestre" />
                            <asp:BoundField DataField="anio" HeaderText="Año" />
                            <asp:BoundField DataField="materia" HeaderText="Materia" />
                            <asp:BoundField DataField="notaNueva" HeaderText="Nota Nueva" />
                            <asp:BoundField DataField="notaVieja" HeaderText="Nota Vieja" />
                            <asp:BoundField DataField="justi" HeaderText="Justificacion" />
                            <asp:TemplateField HeaderText="Gestionar solicitud">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkAceptar" runat="server" CommandArgument='<%# Eval("idSolicitud").ToString() %>' OnCommand="lnkAceptar_Command">Aceptar</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="row ">
                </div>
            </div>
        </div>
</asp:Content>
