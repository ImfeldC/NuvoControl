﻿<%@ Page Title="About Us" Language="C#" Trace="true" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="NuvoControl.Server.WebServer.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        About
    </h2>
    <p>
        Put content here.
    </p>
    <p>
        <asp:Label ID="labelAppInfo" runat="server" Text="(AppInfo)"></asp:Label>
    </p>
</asp:Content>
