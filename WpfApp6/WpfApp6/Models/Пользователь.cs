using System;
using System.Collections.Generic;

namespace WpfApp6.Models;

public partial class Пользователь
{
    public int Код { get; set; }

    public string Роль { get; set; } = null!;

    public string Фио { get; set; } = null!;

    public string Логин { get; set; } = null!;

    public string Пароль { get; set; } = null!;

    public virtual ICollection<Заказ> Заказs { get; set; } = new List<Заказ>();
}
