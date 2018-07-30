<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WebGraph.aspx.cs" Inherits="WebGraph" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Titel" Runat="Server">
    WebGraph
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../dist/vis-network.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../CSS/WebGraph.css" rel="stylesheet" type="text/css" />
    <script src="/dist/vis.js" type="text/javascript"></script>
    <script src="script/WebGraph.js" type="text/javascript"></script>
    <h1>WebGraph</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">


<div class="popUp" id="node-network-popUp">
  <span class="op" id="node-operation">node</span> 
  <table style="margin:auto;"><tr>
    <td>id</td><td><input id="node-id" value="new value" /></td>
  </tr>
    <tr>
      <td>label</td><td><input id="node-label" value="new value" /></td>
    </tr></table>
  <input type="button" value="Hinzufügen" id="saveNodeButton" />
  <input type="button" value="Abbruch" id="cancelNodeButton" />
</div>
<div class="popUp" id="edge-network-popUp">
  <span class="op" id="edge-operation">Edge</span> 
  <table style="margin:auto;"><tr>
    <td>id</td><td><input id="edge-id" value="new value" /></td>
  </tr>
    <tr>
      <td>Value</td><td><input id="edge-value" value="new value" /></td>
    </tr></table>
  <input type="button" value="Hinzufügen" id="saveEdgeButton" />
  <input type="button" value="Abbruch" id="cancelEdgeButton" />
</div>
<div id="containerWrapper">
    <div id="mynetwork"></div>
    <button type="button" class="button" style="vertical-align:middle" id="calulateMST"> <span>Berechne MST</span></button>
</div>
</asp:Content>

