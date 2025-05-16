using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;

namespace Utilities.Notification.Email;

public class NotificationEmail
{
    private readonly string _fromEmail = "jesusdavidfierrorivera817@gmail.com";
    private readonly string _fromName = "RappiGestion";

    public async Task SendWelcomeEmailAsync(string to)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_fromName, _fromEmail));
        message.To.Add(MailboxAddress.Parse(to));
        message.Subject = $"🎉 ¡Bienvenido a {_fromName}!";

        var htmlBody = $@"
        <html>
        <head>
            <style>
                body {{
                    font-family: Arial, sans-serif;
                    background-color: #f4f4f4;
                    margin: 0;
                    padding: 0;
                }}
                .container {{
                    max-width: 600px;
                    margin: 30px auto;
                    background-color: #ffffff;
                    padding: 30px;
                    border-radius: 8px;
                    box-shadow: 0 0 10px rgba(0,0,0,0.1);
                }}
                h1 {{
                    color: #4CAF50;
                }}
                p {{
                    color: #333;
                    font-size: 16px;
                }}
                .footer {{
                    margin-top: 30px;
                    font-size: 12px;
                    color: #aaa;
                    text-align: center;
                }}
            </style>
        </head>
        <body>
            <div class='container'>
                <h1>¡Hola 👋!</h1>
                <p>¡Bienvenido a <strong>{_fromName}</strong>! Estamos encantados de tenerte con nosotros.</p>
                <p>A partir de ahora podrás disfrutar de todas nuestras funcionalidades. Si tienes alguna duda, no dudes en escribirnos.</p>
                <p>Gracias por unirte 🙌</p>
                <div class='footer'>
                    © {DateTime.Now.Year} {_fromName}. Todos los derechos reservados.
                </div>
            </div>
        </body>
        </html>";

        message.Body = new TextPart("html") { Text = htmlBody };

        try
        {
            using var client = new SmtpClient();
            Console.WriteLine("📡 Conectando al servidor SMTP...");
            await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

            Console.WriteLine("🔐 Autenticando...");
            await client.AuthenticateAsync(_fromEmail, "gsgf xhkg fkft sqsb"); // ⚠️ REEMPLAZA por variable de entorno o secreto seguro

            Console.WriteLine("📤 Enviando mensaje...");
            await client.SendAsync(message);

            Console.WriteLine("✅ Correo enviado exitosamente.");
            await client.DisconnectAsync(true);
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error al enviar el correo:");
            Console.WriteLine(ex.Message);
            // Aquí podrías lanzar una excepción personalizada si estás en capa de negocio
            throw new ApplicationException("Error al enviar el correo de bienvenida.", ex);
        }
    }
}
