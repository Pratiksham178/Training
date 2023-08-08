<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NoteBox.ascx.cs" Inherits="RegistrationFormUser.NoteBox" %>

<div id="noteBox" runat="server">
    <div id="message" runat="server" ClientIDMode="Static"></div>
    <div id="userNotes" runat="server" ClientIDMode="Static">
        <asp:GridView runat="server" ID="NotesGridview">
            
        </asp:GridView>
    </div>
   <div class="note_input" runat="server" ClientIdMode="static" id="note_input_box">
        <asp:Textbox ID="addNoteTextBox" runat="server" TextMode="MultiLine" ClientIDMode="Static" ></asp:Textbox>
    <asp:Button ID="addNote" runat="server" OnClick="AddNoteToDB" Text="Add Note" CssClass="btn_AddNote" ClientIDMode="Static" />
   </div>
</div>