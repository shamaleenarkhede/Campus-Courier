<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orderspage.aspx.cs" Inherits="CampusCourier.Orderspage" %>

  <%--
<?xml version="1.0" encoding="utf-8"?>
--%>   
   
                   <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

                        <div>


        <table class="nav-justified">
            <tr>
                <td class="modal-sm" style="width: 235px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 235px">&nbsp;</td>
                <td>&nbsp; 
                 

    <asp:GridView runat="server" ID="ordersGrid"  DataKeyNames="OrderId"
                ItemType="CampusCourier.Models.Orders" SelectMethod="ordersGrid_GetData"
        AutoGenerateColumns="false">
        <Columns>
         

            <asp:DynamicField DataField="OrderId" />
               <%--<asp:TemplateField>   
                                      <ItemTemplate>
                                             <asp:Label Text='<%= Eval("OrderId")%>' runat="server"/>
                                      </ItemTemplate>
               </asp:TemplateField> --%>

            <asp:DynamicField DataField="RestName" />
           <%--  <asp:TemplateField>   
                                      <ItemTemplate>
                                             <asp:Label Text='<%= Eval("RestName")%>' runat="server"/>
                                      </ItemTemplate>
               </asp:TemplateField>--%>

            <asp:DynamicField DataField="Location" />
            <%-- <asp:TemplateField>   
                                      <ItemTemplate>
                                             <asp:Label Text='<%= Eval("Location")%>' runat="server"/>
                                      </ItemTemplate>
               </asp:TemplateField>--%>

            <asp:DynamicField DataField="CustName" />  
            <%-- <asp:TemplateField>   
                                      <ItemTemplate>
                                             <asp:Label Text='<%= Eval("CustName")%>' runat="server"/>
                                      </ItemTemplate>
               </asp:TemplateField>--%>
              
            <asp:DynamicField DataField="Destination" />
            <%-- <asp:TemplateField>   
                                      <ItemTemplate>
                                             <asp:Label Text='<%= Eval("Destination")%>' runat="server"/>
                                      </ItemTemplate>
               </asp:TemplateField>--%>

            <asp:DynamicField DataField="Status" />   
           <%--  <asp:TemplateField>   
                                      <ItemTemplate>
                                             <asp:Label Text='<%= Eval("Status")%>' runat="server"/>
                                      </ItemTemplate>
               </asp:TemplateField>--%>
            
                  
           <%-- <asp:TemplateField HeaderText="Total Credit">
              <ItemTemplate>
                <asp:Label Text="<%# Item.Enrollments.Sum(en => en.Course.Credits) %>" 
                    runat="server" />
              </ItemTemplate>
            </asp:TemplateField> --%>   
                
        </Columns>
    </asp:GridView>

                      </td>
                <td>&nbsp;</td>
            </tr>
        </table>


    </div>

</asp:Content>
