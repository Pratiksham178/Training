<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Notebox.ascx.cs" Inherits="UserManagement.Notebox" %>
<div id="noteBox" runat="server">
    
        <div id="message" class="message">Your Notes</div>
    <div id="userNotes"  class="usernotes"></div>
    <div id="companymessage"  class="message"></div>
    <div id="companyNotes" class="usernotes"></div>
   <div class="note_input"  id="note_input_box">
       <asp:CheckBox ID="checkBoxForPrivateMessage" runat="server" ClientIDMode="Static"/>
        <asp:Textbox ID="addNoteTextBox" runat="server" TextMode="MultiLine" ClientIDMode="Static" ></asp:Textbox>
       
    <asp:Button ID="addNote" runat="server" Text="Add Note" CssClass="btn_AddNote" ClientIDMode="Static" type="button"/>

           </div>
    <span id="privatemessage" runat="server" ClientIDMode="Static"></span>
    
    
</div>