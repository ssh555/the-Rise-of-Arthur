﻿namespace EGamePlay.Combat
{
    using System;
    using System.Collections.Generic;
    using Sirenix.OdinInspector;

    [LabelText("技能类型")]
    public enum SkillSpellType
    {
        [LabelText("主动技能")]
        Initiative,
        [LabelText("被动技能")]
        Passive,
    }

    [LabelText("技能目标检测方式")]
    public enum SkillTargetSelectType
    {
        [LabelText("自动")]
        Auto,
        [LabelText("手动指定")]
        PlayerSelect,
        [LabelText("弹体碰撞检测")]
        BodyCollideSelect,
        [LabelText("固定区域场检测")]
        AreaSelect,
        [LabelText("条件指定")]
        ConditionSelect,
        [LabelText("其他")]
        Other,
    }

    [LabelText("区域场类型")]
    public enum SkillAffectAreaType
    {
        [LabelText("圆形")]
        Circle = 0,
        [LabelText("矩形")]
        Rect = 1,
        [LabelText("组合")]
        Compose = 2,
    }

    //[LabelText("技能作用对象")]
    //public enum SkillAffectTargetType
    //{
    //    [LabelText("自身")]
    //    Self = 0,
    //    [LabelText("己方")]
    //    SelfTeam = 1,
    //    [LabelText("敌方")]
    //    EnemyTeam = 2,
    //}

    [LabelText("技能作用对象")]
    public enum AddSkillEffetTargetType
    {
        [LabelText("技能目标")]
        SkillTarget = 0,
        [LabelText("自身")]
        Self = 1,
        [LabelText("其他")]
        Other = 2,
    }

    [LabelText("目标类型")]
    public enum SkillTargetType
    {
        [LabelText("单体检测")]
        Single = 0,
        [LabelText("多人检测")]
        Multiple = 1,
    }

    [LabelText("伤害类型")]
    public enum DamageType
    {
        [LabelText("物理伤害")]
        Physic = 0,
        //[LabelText("魔法伤害")]
        //Magic = 1,
        [LabelText("真实伤害")]
        Real = 2,
    }

    //[LabelText("效果类型")]
    public enum SkillEffectType
    {
        [LabelText("(添加效果)")]
        None = 0,
        [LabelText("造成伤害")]
        CauseDamage = 1,
        [LabelText("治疗英雄")]
        CureHero = 2,
        [LabelText("施加状态")]
        AddStatus = 3,
        [LabelText("移除状态")]
        RemoveStatus = 4,
        [LabelText("增减数值")]
        NumericModify = 6,
        [LabelText("添加护盾")]
        AddShield = 7,
        [LabelText("标记叠加")]
        StackTag = 8,
        //[LabelText("中毒")]
        //Poison = 9,
        //[LabelText("灼烧")]
        //Burn = 10,
    }

    [Flags]
    [LabelText("行为禁制")]
    public enum ActionControlType
    {
        [LabelText("（空）")]
        None = 0,
        [LabelText("移动禁止")]
        MoveForbid = 1 << 1,
        [LabelText("施法禁止")]
        SkillForbid = 1 << 2,
        [LabelText("攻击禁止")]
        AttackForbid = 1 << 3,
    }

    [LabelText("属性类型")]
    //[LabelWidth(50)]
    public enum AttributeType
    {
        [LabelText("（空）")]
        None = 0,

        [LabelText("生命值上限")]
        HealthPointMax = 999,
        [LabelText("生命值")]
        HealthPoint = 1000,
        [LabelText("攻击力")]
        Attack = 1001,
        [LabelText("护甲值")]
        Defense = 1002,
        [LabelText("法术强度")]
        AbilityPower = 1003,
        [LabelText("魔法抗性")]
        SpellResistance = 1004,
        [LabelText("吸血")]
        SuckBlood = 1005,

        [LabelText("暴击概率")]
        CriticalProbability = 2001,
        [LabelText("移动速度")]
        MoveSpeed = 2002,
        [LabelText("攻击速度")]
        AttackSpeed = 2003,

        [LabelText("护盾值")]
        ShieldValue = 3001,

        [LabelText("造成伤害")]
        CauseDamage = 4001,
    }

    [LabelText("修饰类型")]
    public enum ModifyType
    {
        Add = 0,
        PercentAdd = 1,
        FinalAdd = 2,
        FinalPercentAdd = 3,
    }

    [LabelText("技能碰撞体参数列表")]
    public enum SkillColParams
    {
        [LabelText("作用点位置")]
        targetPoint,
        [LabelText("作用方位")]
        targetDirection,
        [LabelText("作用目标")]
        targetEntity
    }

}