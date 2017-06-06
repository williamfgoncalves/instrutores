using EditoraCrescer.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditoraCrescer.Testes
{
    class NotificacaoAssinanteFake : INotificacaoAssinantes
    {
        public bool NotificouUsuario { get; internal set; }

        public void NotificarNovaPublicacao(string email)
        {
            //Implementação fake, utilizada somente para testes
            this.NotificouUsuario = true;
        }
    }
}
