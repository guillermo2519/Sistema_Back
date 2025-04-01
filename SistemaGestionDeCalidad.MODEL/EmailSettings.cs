using System;
using System.Collections.Generic;


namespace SistemaGestionDeCalidad.MODEL;

public class EmailSettings
{
    public string SMTPServer { get; set; }
    public int SMTPPort { get; set; }
    public string SenderEmail { get; set; }
    public string SenderPassword { get; set; }
}
