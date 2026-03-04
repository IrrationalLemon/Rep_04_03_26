using System;
using System.Collections.Generic;

namespace WpfApp6.Models;

public partial class Заказ
{
    public string Код { get; set; } = null!;

    public int Номер { get; set; }

    public string АртикулТовара { get; set; } = null!;

    public int Количество { get; set; }

    public DateOnly Дата { get; set; }

    public DateOnly ДатаДоставки { get; set; }

    public int КодПунктаВыдачи { get; set; }

    public int КодПользователя { get; set; }

    public int КодПолучения { get; set; }

    public string Статус { get; set; } = null!;

    public virtual Товар АртикулТовараNavigation { get; set; } = null!;

    public virtual Пользователь КодПользователяNavigation { get; set; } = null!;

    public virtual ПунктВыдачи КодПунктаВыдачиNavigation { get; set; } = null!;
}
