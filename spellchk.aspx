<%@ Page Language="C#" AutoEventWireup="true" CodeFile="spellchk.aspx.cs" Inherits="spellchk" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<script type="text/javascript">
        $('#myTextArea').spellCheckInDialog()
        $('textarea').spellAsYouType();
        $(function() {$('textarea').spellAsYouType(defaultDictionary:'Espanol',checkGrammar:true);});
    </script>
<script type="text/javascript" src="jquery/jquery-1.2.6.min.js"></script>
<script type="text/javascript" src="JavaScriptSpellCheck/include.js" ></script>--%>
<script type='text/javascript' src="JavaScriptSpellCheck/include.js"></script>
<script type="text/javascript" src="tinymce/js/tinymce/tinymce.min.js"></script>

<script type="text/javascript">
    tinyMCE.init({ mode: "textareas" });
</script>
</head>
<body>
    <form id="form1" runat="server">
    <%--<div>
    <textarea id="textarea" name="textarea" rows="15" cols="70">
    Welcome to jQuery Spellcheck plugin.

This Examplee iss implemented uisng jQuery and the $() selactor to add spellcheck-as-you type to any textarea , input or editror on any web page.

Teh botton below uses jQuery to launch a spellchecking modal dialog window which is great for form validation.

    </textarea><input type="button"  name="Spell Checking" value="Spell Checking" onclick="$Spelling.SpellCheckInWindow('textarea')" />
    </div>--%> 

    <div>
    <textarea name="myTextArea"  id="myTextArea" cols="30" rows="4">Hello Worlb.</textarea>
    <input type="button" value="Spell Check" onclick="$Spelling.SpellCheckInWindow('editors')" />
    </div>
    </form>
</body>
</html>
