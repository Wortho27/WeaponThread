﻿using static WeaponThread.WeaponStructure.WeaponDefinition;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.ShapeDef.Shapes;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.GraphicDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.TrajectoryDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.TrajectoryDef.GuidanceType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.DamageScaleDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.DamageScaleDef.ShieldDef.ShieldType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AreaDamageDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AreaDamageDef.AreaEffectType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.GraphicDef.LineDef;
namespace WeaponThread
{ // Don't edit above this line
    partial class Weapons
    {
        private AmmoDef AmmoType1 => new AmmoDef
        {
            AmmoMagazine = "Energy",
            AmmoRound = "AmmoType1",
            HybridRound = false, //AmmoMagazine based weapon with energy cost
            EnergyCost = 0.00000000001f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
            BaseDamage = 0.1f,
            Mass = 0f, // in kilograms
            Health = 1000, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
            BackKickForce = 0f,
            HardPointUsable = true, // set to false if this is a shrapnel ammoType and you don't want the turret to be able to select it directly.

            Shape = new ShapeDef //defines the collision shape of projectile, defaults line and visual Line Length if set to 0
            {
                Shape = LineShape,
                Diameter = 1,
            },
            ObjectsHit = new ObjectsHitDef
            {
                MaxObjectsHit = 0, // 0 = disabled
                CountBlocks = false, // counts gridBlocks and not just entities hit
            },
            Shrapnel = new ShrapnelDef
            {
                AmmoRound = "",
                Fragments = 100,
                Degrees = 15,
                Reverse = false,
                RandomizeDir = false, // randomzie between forward and backward directions
            },
            Pattern = new AmmoPatternDef
            {
                Ammos = new[] {
                    "",
                },
                Enable = false,
                TriggerChance = 1f,
                Random = false,
                RandomMin = 1,
                RandomMax = 1,
                SkipParent = false,
            },
            DamageScales = new DamageScaleDef
            {
                MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
                DamageVoxels = false, // true = voxels are vulnerable to this weapon
                SelfDamage = false, // true = allow self damage.

                // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                Characters = -1f,
                FallOff = new FallOffDef
                {
                    Distance = 1000f, // Distance at which max damage begins falling off.
                    MinMultipler = 0.45f, // value from 0.0f to 1f where 0.1f would be a min damage of 10% of max damage.
                },
                Grids = new GridSizeDef
                {
                    Large = -1f,
                    Small = -1f,
                },
                Armor = new ArmorDef
                {
                    Armor = -1f,
                    Light = -1f,
                    Heavy = -1f,
                    NonArmor = -1f,
                },
                Shields = new ShieldDef
                {
                    Modifier = 1f,
                    Type = Kinetic,
                    BypassModifier = -1f,
                },
                // first true/false (ignoreOthers) will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
                Custom = new CustomScalesDef
                {
                    IgnoreAllOthers = false,
                    Types = new[]
                    {
                        new CustomBlocksDef
                        {
                            SubTypeId = "Test1",
                            Modifier = -1f,
                        },
                        new CustomBlocksDef
                        {
                            SubTypeId = "Test2",
                            Modifier = -1f,
                        },
                    },
                },
            },
            AreaEffect = new AreaDamageDef
            {
                AreaEffect = Disabled, // Disabled = do not use area effect at all, Explosive, Radiant, AntiSmart, JumpNullField, JumpNullField, EnergySinkField, AnchorField, EmpField, OffenseField, NavField, DotField.
                AreaEffectDamage = 0f, // 0 = use spillover from BaseDamage, otherwise use this value.
                AreaEffectRadius = 0f,
                Pulse = new PulseDef // interval measured in game ticks (60 == 1 second), pulseChance chance (0 - 100) that an entity in field will be hit
                {
                    Interval = 0,
                    PulseChance = 0,
                },
                Explosions = new ExplosionDef
                {
                    NoVisuals = false,
                    NoSound = false,
                    Scale = 1,
                    CustomParticle = "",
                    CustomSound = "",
                },
                Detonation = new DetonateDef
                {
                    DetonateOnEnd = false,
                    ArmOnlyOnHit = false,
                    DetonationDamage = 1000000,
                    DetonationRadius = 75,
                },
                EwarFields = new EwarFieldsDef
                {
                    Duration = 0,
                    StackDuration = false,
                    Depletable = false,
                    MaxStacks = 10,
                    TriggerRange = 5f,
                },
            },
            Beams = new BeamDef
            {
                Enable = true,
                VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
                RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                OneParticle = false, // Only spawn one particle hit per beam weapon.
            },
            Trajectory = new TrajectoryDef
            {
                Guidance = None,
                TargetLossDegree = 80f,
                TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                MaxLifeTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                AccelPerSec = 0f,
                DesiredSpeed = 300,
                MaxTrajectory = 1000f,
                FieldTime = 0, // 0 is disabled, a value causes the projectile to come to rest, spawn a field and remain for a time (Measured in game ticks, 60 = 1 second)
                GravityMultiplier = 0f, // Gravity multiplier, influences the trajectory of the projectile, value greater than 0 to enable.
                SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
                RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
                MaxTrajectoryTime = 120, // How long the weapon must fire before it reaches MaxTrajectory.
                Smarts = new SmartsDef
                {
                    Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                    Aggressiveness = 1f, // controls how responsive tracking is.
                    MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn
                    TrackingDelay = 1, // Measured in Shape diameter units traveled.
                    MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    OverideTarget = true, // when set to true ammo picks its own target, does not use hardpoint's.
                    MaxTargets = 0, // Number of targets allowed before ending, 0 = unlimited
                    NoTargetExpire = false, // Expire without ever having a target at TargetLossTime
                    Roam = false, // Roam current area after target loss
                },
                Mines = new MinesDef
                {
                    DetectRadius = 200,
                    DeCloakRadius = 100,
                    FieldTime = 1800,
                    Cloak = false,
                    Persist = false,
                },
            },
            AmmoGraphics = new GraphicDef
            {
                ModelName = "",
                VisualProbability = 1f,
                ShieldHitDraw = true,
                Particles = new AmmoParticleDef
                {
                    Ammo = new ParticleDef
                    {
                        Name = "", //ShipWelderArc
                        ShrinkByDistance = false,
                        Color = Color(red: 128, green: 0, blue: 0, alpha: 32),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 1,
                        },
                    },
                    Hit = new ParticleDef
                    {
                        Name = "ShipWelderArc",
                        ApplyToShield = true,
                        ShrinkByDistance = false,
                        Color = Color(red: 243, green: 190, blue: 51, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 30,
                            Scale = 1,
                            HitPlayChance = 1f,
                        },
                    },
                },
                Lines = new LineDef
                {
                    TracerMaterial = "WeaponLaser", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                    ColorVariance = Random(start: 0.75f, end: 2f), // multiply the color by random values within range.
                    WidthVariance = Random(start: 0f, end: 0.025f), // adds random value to default width (negatives shrinks width)
                    Tracer = new TracerBaseDef
                    {
                        Enable = true,
                        Length = 1f,
                        Width = 0.1f,
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        VisualFadeStart = 0, // Number of ticks the weapon has been firing before projectiles begin to fade their color
                        VisualFadeEnd = 0, // How many ticks after fade began before it will be invisible.
                    },
                    Trail = new TrailDef
                    {
                        Enable = false,
                        Material = "WeaponLaser",
                        DecayTime = 128,
                        Color = Color(red: 0, green: 0, blue: 1, alpha: 1),
                        Back = false,
                        CustomWidth = 0,
                        UseWidthVariance = false,
                        UseColorFade = true,
                    },
                    OffsetEffect = new OffsetEffectDef
                    {
                        MaxOffset = 0,// 0 offset value disables this effect
                        MinLength = 0.2f,
                        MaxLength = 3,
                    },
                },
            },
            AmmoAudio = new AmmoAudioDef
            {
                TravelSound = "",
                HitSound = "",
                ShieldHitSound = "",
                PlayerHitSound = "",
                VoxelHitSound = "",
                FloatingHitSound = "",
                HitPlayChance = 0.5f,
                HitPlayShield = true,
            }, // Don't edit below this line
        };
        private AmmoDef AmmoType2 => new AmmoDef
        {
            AmmoMagazine = "Energy",
            AmmoRound = "AmmoType2",
            HybridRound = false, //AmmoMagazine based weapon with energy cost
            EnergyCost = 0.00000000001f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
            BaseDamage = 1000f,
            Mass = 0f, // in kilograms
            Health = 1000, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
            BackKickForce = 0f,
            HardPointUsable = false, // set to false if this is a shrapnel ammoType and you don't want the turret to be able to select it directly.

            Shape = new ShapeDef //defines the collision shape of projectile, defaults line and visual Line Length if set to 0
            {
                Shape = LineShape,
                Diameter = 1,
            },
            ObjectsHit = new ObjectsHitDef
            {
                MaxObjectsHit = 0, // 0 = disabled
                CountBlocks = false, // counts gridBlocks and not just entities hit
            },
            Shrapnel = new ShrapnelDef
            {
                AmmoRound = "",
                Fragments = 0,
                Degrees = 0,
                Reverse = false,
                RandomizeDir = false,
            },
            Pattern = new AmmoPatternDef
            {
                Ammos = new[] {
                    "",
                },
                Enable = false,
                TriggerChance = 0f,
                Random = false,
                RandomMin = 0,
                RandomMax = 0,
                SkipParent = false,
            },
            DamageScales = new DamageScaleDef
            {
                MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
                DamageVoxels = false, // true = voxels are vulnerable to this weapon
                SelfDamage = false, // true = allow self damage.

                // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                Characters = -1f,
                FallOff = new FallOffDef
                {
                    Distance = 1000f, // Distance at which max damage begins falling off.
                    MinMultipler = 0.45f, // value from 0.0f to 1f where 0.1f would be a min damage of 10% of max damage.
                },
                Grids = new GridSizeDef
                {
                    Large = -1f,
                    Small = -1f,
                },
                Armor = new ArmorDef
                {
                    Armor = -1f,
                    Light = -1f,
                    Heavy = -1f,
                    NonArmor = -1f,
                },
                Shields = new ShieldDef
                {
                    Modifier = 1f,
                    Type = Kinetic,
                    BypassModifier = -1f,
                },
                // first true/false (ignoreOthers) will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
                Custom = new CustomScalesDef
                {
                    IgnoreAllOthers = false,
                    Types = new[] {
                        new CustomBlocksDef
                        {
                            SubTypeId = "Test1",
                            Modifier = -1f,
                        },
                        new CustomBlocksDef
                        {
                            SubTypeId = "Test2",
                            Modifier = -1f,
                        },
                    },
                },
            },
            AreaEffect = new AreaDamageDef
            {
                AreaEffect = DotField, // Disabled = do not use area effect at all, Explosive, Radiant, AntiSmart, JumpNullField, JumpNullField, EnergySinkField, AnchorField, EmpField, OffenseField, NavField, DotField.
                AreaEffectDamage = 10000f, // 0 = use spillover from BaseDamage, otherwise use this value.
                AreaEffectRadius = 20f,
                Pulse = new PulseDef // interval measured in game ticks (60 == 1 second), pulseChance chance (0 - 100) that an entity in field will be hit
                {
                    Interval = 60,
                    PulseChance = 75,
                },
                Explosions = new ExplosionDef
                {
                    NoVisuals = false,
                    NoSound = false,
                    Scale = 1,
                    CustomParticle = "",
                    CustomSound = "",
                },
                Detonation = new DetonateDef
                {
                    DetonateOnEnd = false,
                    ArmOnlyOnHit = false,
                    DetonationDamage = 100000,
                    DetonationRadius = 75,
                },
                EwarFields = new EwarFieldsDef
                {
                    Duration = 60,
                    StackDuration = true,
                    Depletable = false,
                    MaxStacks = 10,
                    TriggerRange = 5f,
                },
            },
            Beams = new BeamDef
            {
                Enable = true,
                VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
                RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                OneParticle = false, // Only spawn one particle hit per beam weapon.
            },
            Trajectory = new TrajectoryDef
            {
                Guidance = None,
                TargetLossDegree = 80f,
                TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                MaxLifeTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                AccelPerSec = 0f,
                DesiredSpeed = 300,
                MaxTrajectory = 1000f,
                FieldTime = 0, // 0 is disabled, a value causes the projectile to come to rest, spawn a field and remain for a time (Measured in game ticks, 60 = 1 second)
                GravityMultiplier = 0f, // Gravity influences the trajectory of the projectile.
                SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
                RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
                Smarts = new SmartsDef
                {
                    Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                    Aggressiveness = 1f, // controls how responsive tracking is.
                    MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn
                    TrackingDelay = 1, // Measured in Shape diameter units traveled.
                    MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    OverideTarget = true, // when set to true ammo picks its own target, does not use hardpoint's.
                    MaxTargets = 0, // Number of targets allowed before ending, 0 = unlimited
                    NoTargetExpire = false, // Expire without ever having a target at TargetLossTime
                    Roam = false, // Roam current area after target loss
                },
                Mines = new MinesDef
                {
                    DetectRadius = 200,
                    DeCloakRadius = 100,
                    FieldTime = 1800,
                    Cloak = false,
                    Persist = false,
                },
            },
            AmmoGraphics = new GraphicDef
            {
                ModelName = "",
                VisualProbability = 1f,
                ShieldHitDraw = true,
                Particles = new AmmoParticleDef
                {
                    Ammo = new ParticleDef
                    {
                        Name = "", //ShipWelderArc
                        ShrinkByDistance = false,
                        Color = Color(red: 0, green: 0, blue: 64, alpha: 32),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 1,
                        },
                    },
                    Hit = new ParticleDef
                    {
                        Name = "ShipWelderArc",
                        ApplyToShield = true,
                        ShrinkByDistance = false,
                        Color = Color(red: 243, green: 190, blue: 51, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 1,
                            HitPlayChance = 1f,
                        },
                    },
                },
                Lines = new LineDef
                {
                    TracerMaterial = "WeaponLaser", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                    ColorVariance = Random(start: 0.75f, end: 2f), // multiply the color by random values within range.
                    WidthVariance = Random(start: 0f, end: 0.025f), // adds random value to default width (negatives shrinks width)
                    Tracer = new TracerBaseDef
                    {
                        Enable = true,
                        Length = 1f,
                        Width = 0.1f,
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                    },
                    Trail = new TrailDef
                    {
                        Enable = false,
                        Material = "WeaponLaser",
                        DecayTime = 128,
                        Color = Color(red: 0, green: 0, blue: 1, alpha: 1),
                        Back = false,
                        CustomWidth = 0,
                        UseWidthVariance = false,
                        UseColorFade = true,
                    },
                    OffsetEffect = new OffsetEffectDef
                    {
                        MaxOffset = 0,// 0 offset value disables this effect
                        MinLength = 0.2f,
                        MaxLength = 3,
                    },
                },
            },
            AmmoAudio = new AmmoAudioDef
            {
                TravelSound = "ArcWepShipGatlingRotation",
                HitSound = "",
                ShieldHitSound = "",
                PlayerHitSound = "",
                VoxelHitSound = "",
                FloatingHitSound = "",
                HitPlayChance = 0.5f,
                HitPlayShield = true,
            }, // Don't edit below this line
        };
    }
}
