<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Service Areas</h3>
    <p>Northwind Traders provides your supply and service needs in the following regions.</p>

    <%-- use repeater if your intrested in viewing and listview if your intrested in editing the data\
        gridview allows you to view edit delete information. the list view allows you to view edit delete and insert information--%>
    <div class="row">
        <asp:Repeater ID="RegionRepeater" runat="server" 
             DataSourceID="RegionsDataSource"
             ItemType="NorthwindTraders.Entities.Region"> <%--Fully qualified class name. Namespace.classname--%>
            <ItemTemplate>
                <div class="col-md-3">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4><%# Item.RegionDescription %></h4> <%--item.will bring up intellesense--%>
                        </div>
                        <div class="panel-body">
                            <asp:Repeater ID="TerritoryRepeater" runat="server"
                                 DataSource="<%# Item.Territories %>"
                                 ItemType="NorthwindTraders.Entities.Territory">
                                <ItemTemplate><%# Item.TerritoryDescription.Trim() %></ItemTemplate>
                                <SeparatorTemplate>, </SeparatorTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <img src="Images/NorthwindLogoLarge.png" />

    <asp:ObjectDataSource ID="RegionsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllRegions" TypeName="NorthwindTraders.BLL.CRUD.RegionController"></asp:ObjectDataSource>
</asp:Content>
