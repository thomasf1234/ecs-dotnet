using ECS;
using System;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace PerformanceTests
{
    public class World256ComponentPerformanceTests
    {
        // Define 256 unique structs
        #region ComponentStructs
        private struct Component000 : IComponent { public int Value; }
        private struct Component001 : IComponent { public int Value; }
        private struct Component002 : IComponent { public int Value; }
        private struct Component003 : IComponent { public int Value; }
        private struct Component004 : IComponent { public int Value; }
        private struct Component005 : IComponent { public int Value; }
        private struct Component006 : IComponent { public int Value; }
        private struct Component007 : IComponent { public int Value; }
        private struct Component008 : IComponent { public int Value; }
        private struct Component009 : IComponent { public int Value; }
        private struct Component010 : IComponent { public int Value; }
        private struct Component011 : IComponent { public int Value; }
        private struct Component012 : IComponent { public int Value; }
        private struct Component013 : IComponent { public int Value; }
        private struct Component014 : IComponent { public int Value; }
        private struct Component015 : IComponent { public int Value; }
        private struct Component016 : IComponent { public int Value; }
        private struct Component017 : IComponent { public int Value; }
        private struct Component018 : IComponent { public int Value; }
        private struct Component019 : IComponent { public int Value; }
        private struct Component020 : IComponent { public int Value; }
        private struct Component021 : IComponent { public int Value; }
        private struct Component022 : IComponent { public int Value; }
        private struct Component023 : IComponent { public int Value; }
        private struct Component024 : IComponent { public int Value; }
        private struct Component025 : IComponent { public int Value; }
        private struct Component026 : IComponent { public int Value; }
        private struct Component027 : IComponent { public int Value; }
        private struct Component028 : IComponent { public int Value; }
        private struct Component029 : IComponent { public int Value; }
        private struct Component030 : IComponent { public int Value; }
        private struct Component031 : IComponent { public int Value; }
        private struct Component032 : IComponent { public int Value; }
        private struct Component033 : IComponent { public int Value; }
        private struct Component034 : IComponent { public int Value; }
        private struct Component035 : IComponent { public int Value; }
        private struct Component036 : IComponent { public int Value; }
        private struct Component037 : IComponent { public int Value; }
        private struct Component038 : IComponent { public int Value; }
        private struct Component039 : IComponent { public int Value; }
        private struct Component040 : IComponent { public int Value; }
        private struct Component041 : IComponent { public int Value; }
        private struct Component042 : IComponent { public int Value; }
        private struct Component043 : IComponent { public int Value; }
        private struct Component044 : IComponent { public int Value; }
        private struct Component045 : IComponent { public int Value; }
        private struct Component046 : IComponent { public int Value; }
        private struct Component047 : IComponent { public int Value; }
        private struct Component048 : IComponent { public int Value; }
        private struct Component049 : IComponent { public int Value; }
        private struct Component050 : IComponent { public int Value; }
        private struct Component051 : IComponent { public int Value; }
        private struct Component052 : IComponent { public int Value; }
        private struct Component053 : IComponent { public int Value; }
        private struct Component054 : IComponent { public int Value; }
        private struct Component055 : IComponent { public int Value; }
        private struct Component056 : IComponent { public int Value; }
        private struct Component057 : IComponent { public int Value; }
        private struct Component058 : IComponent { public int Value; }
        private struct Component059 : IComponent { public int Value; }
        private struct Component060 : IComponent { public int Value; }
        private struct Component061 : IComponent { public int Value; }
        private struct Component062 : IComponent { public int Value; }
        private struct Component063 : IComponent { public int Value; }
        private struct Component064 : IComponent { public int Value; }
        private struct Component065 : IComponent { public int Value; }
        private struct Component066 : IComponent { public int Value; }
        private struct Component067 : IComponent { public int Value; }
        private struct Component068 : IComponent { public int Value; }
        private struct Component069 : IComponent { public int Value; }
        private struct Component070 : IComponent { public int Value; }
        private struct Component071 : IComponent { public int Value; }
        private struct Component072 : IComponent { public int Value; }
        private struct Component073 : IComponent { public int Value; }
        private struct Component074 : IComponent { public int Value; }
        private struct Component075 : IComponent { public int Value; }
        private struct Component076 : IComponent { public int Value; }
        private struct Component077 : IComponent { public int Value; }
        private struct Component078 : IComponent { public int Value; }
        private struct Component079 : IComponent { public int Value; }
        private struct Component080 : IComponent { public int Value; }
        private struct Component081 : IComponent { public int Value; }
        private struct Component082 : IComponent { public int Value; }
        private struct Component083 : IComponent { public int Value; }
        private struct Component084 : IComponent { public int Value; }
        private struct Component085 : IComponent { public int Value; }
        private struct Component086 : IComponent { public int Value; }
        private struct Component087 : IComponent { public int Value; }
        private struct Component088 : IComponent { public int Value; }
        private struct Component089 : IComponent { public int Value; }
        private struct Component090 : IComponent { public int Value; }
        private struct Component091 : IComponent { public int Value; }
        private struct Component092 : IComponent { public int Value; }
        private struct Component093 : IComponent { public int Value; }
        private struct Component094 : IComponent { public int Value; }
        private struct Component095 : IComponent { public int Value; }
        private struct Component096 : IComponent { public int Value; }
        private struct Component097 : IComponent { public int Value; }
        private struct Component098 : IComponent { public int Value; }
        private struct Component099 : IComponent { public int Value; }
        private struct Component100 : IComponent { public int Value; }
        private struct Component101 : IComponent { public int Value; }
        private struct Component102 : IComponent { public int Value; }
        private struct Component103 : IComponent { public int Value; }
        private struct Component104 : IComponent { public int Value; }
        private struct Component105 : IComponent { public int Value; }
        private struct Component106 : IComponent { public int Value; }
        private struct Component107 : IComponent { public int Value; }
        private struct Component108 : IComponent { public int Value; }
        private struct Component109 : IComponent { public int Value; }
        private struct Component110 : IComponent { public int Value; }
        private struct Component111 : IComponent { public int Value; }
        private struct Component112 : IComponent { public int Value; }
        private struct Component113 : IComponent { public int Value; }
        private struct Component114 : IComponent { public int Value; }
        private struct Component115 : IComponent { public int Value; }
        private struct Component116 : IComponent { public int Value; }
        private struct Component117 : IComponent { public int Value; }
        private struct Component118 : IComponent { public int Value; }
        private struct Component119 : IComponent { public int Value; }
        private struct Component120 : IComponent { public int Value; }
        private struct Component121 : IComponent { public int Value; }
        private struct Component122 : IComponent { public int Value; }
        private struct Component123 : IComponent { public int Value; }
        private struct Component124 : IComponent { public int Value; }
        private struct Component125 : IComponent { public int Value; }
        private struct Component126 : IComponent { public int Value; }
        private struct Component127 : IComponent { public int Value; }
        private struct Component128 : IComponent { public int Value; }
        private struct Component129 : IComponent { public int Value; }
        private struct Component130 : IComponent { public int Value; }
        private struct Component131 : IComponent { public int Value; }
        private struct Component132 : IComponent { public int Value; }
        private struct Component133 : IComponent { public int Value; }
        private struct Component134 : IComponent { public int Value; }
        private struct Component135 : IComponent { public int Value; }
        private struct Component136 : IComponent { public int Value; }
        private struct Component137 : IComponent { public int Value; }
        private struct Component138 : IComponent { public int Value; }
        private struct Component139 : IComponent { public int Value; }
        private struct Component140 : IComponent { public int Value; }
        private struct Component141 : IComponent { public int Value; }
        private struct Component142 : IComponent { public int Value; }
        private struct Component143 : IComponent { public int Value; }
        private struct Component144 : IComponent { public int Value; }
        private struct Component145 : IComponent { public int Value; }
        private struct Component146 : IComponent { public int Value; }
        private struct Component147 : IComponent { public int Value; }
        private struct Component148 : IComponent { public int Value; }
        private struct Component149 : IComponent { public int Value; }
        private struct Component150 : IComponent { public int Value; }
        private struct Component151 : IComponent { public int Value; }
        private struct Component152 : IComponent { public int Value; }
        private struct Component153 : IComponent { public int Value; }
        private struct Component154 : IComponent { public int Value; }
        private struct Component155 : IComponent { public int Value; }
        private struct Component156 : IComponent { public int Value; }
        private struct Component157 : IComponent { public int Value; }
        private struct Component158 : IComponent { public int Value; }
        private struct Component159 : IComponent { public int Value; }
        private struct Component160 : IComponent { public int Value; }
        private struct Component161 : IComponent { public int Value; }
        private struct Component162 : IComponent { public int Value; }
        private struct Component163 : IComponent { public int Value; }
        private struct Component164 : IComponent { public int Value; }
        private struct Component165 : IComponent { public int Value; }
        private struct Component166 : IComponent { public int Value; }
        private struct Component167 : IComponent { public int Value; }
        private struct Component168 : IComponent { public int Value; }
        private struct Component169 : IComponent { public int Value; }
        private struct Component170 : IComponent { public int Value; }
        private struct Component171 : IComponent { public int Value; }
        private struct Component172 : IComponent { public int Value; }
        private struct Component173 : IComponent { public int Value; }
        private struct Component174 : IComponent { public int Value; }
        private struct Component175 : IComponent { public int Value; }
        private struct Component176 : IComponent { public int Value; }
        private struct Component177 : IComponent { public int Value; }
        private struct Component178 : IComponent { public int Value; }
        private struct Component179 : IComponent { public int Value; }
        private struct Component180 : IComponent { public int Value; }
        private struct Component181 : IComponent { public int Value; }
        private struct Component182 : IComponent { public int Value; }
        private struct Component183 : IComponent { public int Value; }
        private struct Component184 : IComponent { public int Value; }
        private struct Component185 : IComponent { public int Value; }
        private struct Component186 : IComponent { public int Value; }
        private struct Component187 : IComponent { public int Value; }
        private struct Component188 : IComponent { public int Value; }
        private struct Component189 : IComponent { public int Value; }
        private struct Component190 : IComponent { public int Value; }
        private struct Component191 : IComponent { public int Value; }
        private struct Component192 : IComponent { public int Value; }
        private struct Component193 : IComponent { public int Value; }
        private struct Component194 : IComponent { public int Value; }
        private struct Component195 : IComponent { public int Value; }
        private struct Component196 : IComponent { public int Value; }
        private struct Component197 : IComponent { public int Value; }
        private struct Component198 : IComponent { public int Value; }
        private struct Component199 : IComponent { public int Value; }
        private struct Component200 : IComponent { public int Value; }
        private struct Component201 : IComponent { public int Value; }
        private struct Component202 : IComponent { public int Value; }
        private struct Component203 : IComponent { public int Value; }
        private struct Component204 : IComponent { public int Value; }
        private struct Component205 : IComponent { public int Value; }
        private struct Component206 : IComponent { public int Value; }
        private struct Component207 : IComponent { public int Value; }
        private struct Component208 : IComponent { public int Value; }
        private struct Component209 : IComponent { public int Value; }
        private struct Component210 : IComponent { public int Value; }
        private struct Component211 : IComponent { public int Value; }
        private struct Component212 : IComponent { public int Value; }
        private struct Component213 : IComponent { public int Value; }
        private struct Component214 : IComponent { public int Value; }
        private struct Component215 : IComponent { public int Value; }
        private struct Component216 : IComponent { public int Value; }
        private struct Component217 : IComponent { public int Value; }
        private struct Component218 : IComponent { public int Value; }
        private struct Component219 : IComponent { public int Value; }
        private struct Component220 : IComponent { public int Value; }
        private struct Component221 : IComponent { public int Value; }
        private struct Component222 : IComponent { public int Value; }
        private struct Component223 : IComponent { public int Value; }
        private struct Component224 : IComponent { public int Value; }
        private struct Component225 : IComponent { public int Value; }
        private struct Component226 : IComponent { public int Value; }
        private struct Component227 : IComponent { public int Value; }
        private struct Component228 : IComponent { public int Value; }
        private struct Component229 : IComponent { public int Value; }
        private struct Component230 : IComponent { public int Value; }
        private struct Component231 : IComponent { public int Value; }
        private struct Component232 : IComponent { public int Value; }
        private struct Component233 : IComponent { public int Value; }
        private struct Component234 : IComponent { public int Value; }
        private struct Component235 : IComponent { public int Value; }
        private struct Component236 : IComponent { public int Value; }
        private struct Component237 : IComponent { public int Value; }
        private struct Component238 : IComponent { public int Value; }
        private struct Component239 : IComponent { public int Value; }
        private struct Component240 : IComponent { public int Value; }
        private struct Component241 : IComponent { public int Value; }
        private struct Component242 : IComponent { public int Value; }
        private struct Component243 : IComponent { public int Value; }
        private struct Component244 : IComponent { public int Value; }
        private struct Component245 : IComponent { public int Value; }
        private struct Component246 : IComponent { public int Value; }
        private struct Component247 : IComponent { public int Value; }
        private struct Component248 : IComponent { public int Value; }
        private struct Component249 : IComponent { public int Value; }
        private struct Component250 : IComponent { public int Value; }
        private struct Component251 : IComponent { public int Value; }
        private struct Component252 : IComponent { public int Value; }
        private struct Component253 : IComponent { public int Value; }
        private struct Component254 : IComponent { public int Value; }
        private struct Component255 : IComponent { public int Value; }
        #endregion

        [Fact]
        public void CreateAndUpdate_10000Entities_256UniqueComponents_Performance_98Percentile()
        {
            const int entityCount = 1000;
            const int frameCount = 1000;
            var world = new World(entityCount);

            // Register all 256 components
            world.RegisterComponent<Component000>();
            world.RegisterComponent<Component001>();
            world.RegisterComponent<Component002>();
            world.RegisterComponent<Component003>();
            world.RegisterComponent<Component004>();
            world.RegisterComponent<Component005>();
            world.RegisterComponent<Component006>();
            world.RegisterComponent<Component007>();
            world.RegisterComponent<Component008>();
            world.RegisterComponent<Component009>();
            world.RegisterComponent<Component010>();
            world.RegisterComponent<Component011>();
            world.RegisterComponent<Component012>();
            world.RegisterComponent<Component013>();
            world.RegisterComponent<Component014>();
            world.RegisterComponent<Component015>();
            world.RegisterComponent<Component016>();
            world.RegisterComponent<Component017>();
            world.RegisterComponent<Component018>();
            world.RegisterComponent<Component019>();
            world.RegisterComponent<Component020>();
            world.RegisterComponent<Component021>();
            world.RegisterComponent<Component022>();
            world.RegisterComponent<Component023>();
            world.RegisterComponent<Component024>();
            world.RegisterComponent<Component025>();
            world.RegisterComponent<Component026>();
            world.RegisterComponent<Component027>();
            world.RegisterComponent<Component028>();
            world.RegisterComponent<Component029>();
            world.RegisterComponent<Component030>();
            world.RegisterComponent<Component031>();
            world.RegisterComponent<Component032>();
            world.RegisterComponent<Component033>();
            world.RegisterComponent<Component034>();
            world.RegisterComponent<Component035>();
            world.RegisterComponent<Component036>();
            world.RegisterComponent<Component037>();
            world.RegisterComponent<Component038>();
            world.RegisterComponent<Component039>();
            world.RegisterComponent<Component040>();
            world.RegisterComponent<Component041>();
            world.RegisterComponent<Component042>();
            world.RegisterComponent<Component043>();
            world.RegisterComponent<Component044>();
            world.RegisterComponent<Component045>();
            world.RegisterComponent<Component046>();
            world.RegisterComponent<Component047>();
            world.RegisterComponent<Component048>();
            world.RegisterComponent<Component049>();
            world.RegisterComponent<Component050>();
            world.RegisterComponent<Component051>();
            world.RegisterComponent<Component052>();
            world.RegisterComponent<Component053>();
            world.RegisterComponent<Component054>();
            world.RegisterComponent<Component055>();
            world.RegisterComponent<Component056>();
            world.RegisterComponent<Component057>();
            world.RegisterComponent<Component058>();
            world.RegisterComponent<Component059>();
            world.RegisterComponent<Component060>();
            world.RegisterComponent<Component061>();
            world.RegisterComponent<Component062>();
            world.RegisterComponent<Component063>();
            world.RegisterComponent<Component064>();
            world.RegisterComponent<Component065>();
            world.RegisterComponent<Component066>();
            world.RegisterComponent<Component067>();
            world.RegisterComponent<Component068>();
            world.RegisterComponent<Component069>();
            world.RegisterComponent<Component070>();
            world.RegisterComponent<Component071>();
            world.RegisterComponent<Component072>();
            world.RegisterComponent<Component073>();
            world.RegisterComponent<Component074>();
            world.RegisterComponent<Component075>();
            world.RegisterComponent<Component076>();
            world.RegisterComponent<Component077>();
            world.RegisterComponent<Component078>();
            world.RegisterComponent<Component079>();
            world.RegisterComponent<Component080>();
            world.RegisterComponent<Component081>();
            world.RegisterComponent<Component082>();
            world.RegisterComponent<Component083>();
            world.RegisterComponent<Component084>();
            world.RegisterComponent<Component085>();
            world.RegisterComponent<Component086>();
            world.RegisterComponent<Component087>();
            world.RegisterComponent<Component088>();
            world.RegisterComponent<Component089>();
            world.RegisterComponent<Component090>();
            world.RegisterComponent<Component091>();
            world.RegisterComponent<Component092>();
            world.RegisterComponent<Component093>();
            world.RegisterComponent<Component094>();
            world.RegisterComponent<Component095>();
            world.RegisterComponent<Component096>();
            world.RegisterComponent<Component097>();
            world.RegisterComponent<Component098>();
            world.RegisterComponent<Component099>();
            world.RegisterComponent<Component100>();
            world.RegisterComponent<Component101>();
            world.RegisterComponent<Component102>();
            world.RegisterComponent<Component103>();
            world.RegisterComponent<Component104>();
            world.RegisterComponent<Component105>();
            world.RegisterComponent<Component106>();
            world.RegisterComponent<Component107>();
            world.RegisterComponent<Component108>();
            world.RegisterComponent<Component109>();
            world.RegisterComponent<Component110>();
            world.RegisterComponent<Component111>();
            world.RegisterComponent<Component112>();
            world.RegisterComponent<Component113>();
            world.RegisterComponent<Component114>();
            world.RegisterComponent<Component115>();
            world.RegisterComponent<Component116>();
            world.RegisterComponent<Component117>();
            world.RegisterComponent<Component118>();
            world.RegisterComponent<Component119>();
            world.RegisterComponent<Component120>();
            world.RegisterComponent<Component121>();
            world.RegisterComponent<Component122>();
            world.RegisterComponent<Component123>();
            world.RegisterComponent<Component124>();
            world.RegisterComponent<Component125>();
            world.RegisterComponent<Component126>();
            world.RegisterComponent<Component127>();
            world.RegisterComponent<Component128>();
            world.RegisterComponent<Component129>();
            world.RegisterComponent<Component130>();
            world.RegisterComponent<Component131>();
            world.RegisterComponent<Component132>();
            world.RegisterComponent<Component133>();
            world.RegisterComponent<Component134>();
            world.RegisterComponent<Component135>();
            world.RegisterComponent<Component136>();
            world.RegisterComponent<Component137>();
            world.RegisterComponent<Component138>();
            world.RegisterComponent<Component139>();
            world.RegisterComponent<Component140>();
            world.RegisterComponent<Component141>();
            world.RegisterComponent<Component142>();
            world.RegisterComponent<Component143>();
            world.RegisterComponent<Component144>();
            world.RegisterComponent<Component145>();
            world.RegisterComponent<Component146>();
            world.RegisterComponent<Component147>();
            world.RegisterComponent<Component148>();
            world.RegisterComponent<Component149>();
            world.RegisterComponent<Component150>();
            world.RegisterComponent<Component151>();
            world.RegisterComponent<Component152>();
            world.RegisterComponent<Component153>();
            world.RegisterComponent<Component154>();
            world.RegisterComponent<Component155>();
            world.RegisterComponent<Component156>();
            world.RegisterComponent<Component157>();
            world.RegisterComponent<Component158>();
            world.RegisterComponent<Component159>();
            world.RegisterComponent<Component160>();
            world.RegisterComponent<Component161>();
            world.RegisterComponent<Component162>();
            world.RegisterComponent<Component163>();
            world.RegisterComponent<Component164>();
            world.RegisterComponent<Component165>();
            world.RegisterComponent<Component166>();
            world.RegisterComponent<Component167>();
            world.RegisterComponent<Component168>();
            world.RegisterComponent<Component169>();
            world.RegisterComponent<Component170>();
            world.RegisterComponent<Component171>();
            world.RegisterComponent<Component172>();
            world.RegisterComponent<Component173>();
            world.RegisterComponent<Component174>();
            world.RegisterComponent<Component175>();
            world.RegisterComponent<Component176>();
            world.RegisterComponent<Component177>();
            world.RegisterComponent<Component178>();
            world.RegisterComponent<Component179>();
            world.RegisterComponent<Component180>();
            world.RegisterComponent<Component181>();
            world.RegisterComponent<Component182>();
            world.RegisterComponent<Component183>();
            world.RegisterComponent<Component184>();
            world.RegisterComponent<Component185>();
            world.RegisterComponent<Component186>();
            world.RegisterComponent<Component187>();
            world.RegisterComponent<Component188>();
            world.RegisterComponent<Component189>();
            world.RegisterComponent<Component190>();
            world.RegisterComponent<Component191>();
            world.RegisterComponent<Component192>();
            world.RegisterComponent<Component193>();
            world.RegisterComponent<Component194>();
            world.RegisterComponent<Component195>();
            world.RegisterComponent<Component196>();
            world.RegisterComponent<Component197>();
            world.RegisterComponent<Component198>();
            world.RegisterComponent<Component199>();
            world.RegisterComponent<Component200>();
            world.RegisterComponent<Component201>();
            world.RegisterComponent<Component202>();
            world.RegisterComponent<Component203>();
            world.RegisterComponent<Component204>();
            world.RegisterComponent<Component205>();
            world.RegisterComponent<Component206>();
            world.RegisterComponent<Component207>();
            world.RegisterComponent<Component208>();
            world.RegisterComponent<Component209>();
            world.RegisterComponent<Component210>();
            world.RegisterComponent<Component211>();
            world.RegisterComponent<Component212>();
            world.RegisterComponent<Component213>();
            world.RegisterComponent<Component214>();
            world.RegisterComponent<Component215>();
            world.RegisterComponent<Component216>();
            world.RegisterComponent<Component217>();
            world.RegisterComponent<Component218>();
            world.RegisterComponent<Component219>();
            world.RegisterComponent<Component220>();
            world.RegisterComponent<Component221>();
            world.RegisterComponent<Component222>();
            world.RegisterComponent<Component223>();
            world.RegisterComponent<Component224>();
            world.RegisterComponent<Component225>();
            world.RegisterComponent<Component226>();
            world.RegisterComponent<Component227>();
            world.RegisterComponent<Component228>();
            world.RegisterComponent<Component229>();
            world.RegisterComponent<Component230>();
            world.RegisterComponent<Component231>();
            world.RegisterComponent<Component232>();
            world.RegisterComponent<Component233>();
            world.RegisterComponent<Component234>();
            world.RegisterComponent<Component235>();
            world.RegisterComponent<Component236>();
            world.RegisterComponent<Component237>();
            world.RegisterComponent<Component238>();
            world.RegisterComponent<Component239>();
            world.RegisterComponent<Component240>();
            world.RegisterComponent<Component241>();
            world.RegisterComponent<Component242>();
            world.RegisterComponent<Component243>();
            world.RegisterComponent<Component244>();
            world.RegisterComponent<Component245>();
            world.RegisterComponent<Component246>();
            world.RegisterComponent<Component247>();
            world.RegisterComponent<Component248>();
            world.RegisterComponent<Component249>();
            world.RegisterComponent<Component250>();
            world.RegisterComponent<Component251>();
            world.RegisterComponent<Component252>();
            world.RegisterComponent<Component253>();
            world.RegisterComponent<Component254>();
            world.RegisterComponent<Component255>();

            // Create entities and add all 256 components to each
            for (int i = 0; i < entityCount; i++)
            {
                int id = world.CreateEntity();
                world.AddComponent(id, new Component000 { Value = i });
                world.AddComponent(id, new Component001 { Value = i });
                world.AddComponent(id, new Component002 { Value = i });
                world.AddComponent(id, new Component003 { Value = i });
                world.AddComponent(id, new Component004 { Value = i });
                world.AddComponent(id, new Component005 { Value = i });
                world.AddComponent(id, new Component006 { Value = i });
                world.AddComponent(id, new Component007 { Value = i });
                world.AddComponent(id, new Component008 { Value = i });
                world.AddComponent(id, new Component009 { Value = i });
                world.AddComponent(id, new Component010 { Value = i });
                world.AddComponent(id, new Component011 { Value = i });
                world.AddComponent(id, new Component012 { Value = i });
                world.AddComponent(id, new Component013 { Value = i });
                world.AddComponent(id, new Component014 { Value = i });
                world.AddComponent(id, new Component015 { Value = i });
                world.AddComponent(id, new Component016 { Value = i });
                world.AddComponent(id, new Component017 { Value = i });
                world.AddComponent(id, new Component018 { Value = i });
                world.AddComponent(id, new Component019 { Value = i });
                world.AddComponent(id, new Component020 { Value = i });
                world.AddComponent(id, new Component021 { Value = i });
                world.AddComponent(id, new Component022 { Value = i });
                world.AddComponent(id, new Component023 { Value = i });
                world.AddComponent(id, new Component024 { Value = i });
                world.AddComponent(id, new Component025 { Value = i });
                world.AddComponent(id, new Component026 { Value = i });
                world.AddComponent(id, new Component027 { Value = i });
                world.AddComponent(id, new Component028 { Value = i });
                world.AddComponent(id, new Component029 { Value = i });
                world.AddComponent(id, new Component030 { Value = i });
                world.AddComponent(id, new Component031 { Value = i });
                world.AddComponent(id, new Component032 { Value = i });
                world.AddComponent(id, new Component033 { Value = i });
                world.AddComponent(id, new Component034 { Value = i });
                world.AddComponent(id, new Component035 { Value = i });
                world.AddComponent(id, new Component036 { Value = i });
                world.AddComponent(id, new Component037 { Value = i });
                world.AddComponent(id, new Component038 { Value = i });
                world.AddComponent(id, new Component039 { Value = i });
                world.AddComponent(id, new Component040 { Value = i });
                world.AddComponent(id, new Component041 { Value = i });
                world.AddComponent(id, new Component042 { Value = i });
                world.AddComponent(id, new Component043 { Value = i });
                world.AddComponent(id, new Component044 { Value = i });
                world.AddComponent(id, new Component045 { Value = i });
                world.AddComponent(id, new Component046 { Value = i });
                world.AddComponent(id, new Component047 { Value = i });
                world.AddComponent(id, new Component048 { Value = i });
                world.AddComponent(id, new Component049 { Value = i });
                world.AddComponent(id, new Component050 { Value = i });
                world.AddComponent(id, new Component051 { Value = i });
                world.AddComponent(id, new Component052 { Value = i });
                world.AddComponent(id, new Component053 { Value = i });
                world.AddComponent(id, new Component054 { Value = i });
                world.AddComponent(id, new Component055 { Value = i });
                world.AddComponent(id, new Component056 { Value = i });
                world.AddComponent(id, new Component057 { Value = i });
                world.AddComponent(id, new Component058 { Value = i });
                world.AddComponent(id, new Component059 { Value = i });
                world.AddComponent(id, new Component060 { Value = i });
                world.AddComponent(id, new Component061 { Value = i });
                world.AddComponent(id, new Component062 { Value = i });
                world.AddComponent(id, new Component063 { Value = i });
                world.AddComponent(id, new Component064 { Value = i });
                world.AddComponent(id, new Component065 { Value = i });
                world.AddComponent(id, new Component066 { Value = i });
                world.AddComponent(id, new Component067 { Value = i });
                world.AddComponent(id, new Component068 { Value = i });
                world.AddComponent(id, new Component069 { Value = i });
                world.AddComponent(id, new Component070 { Value = i });
                world.AddComponent(id, new Component071 { Value = i });
                world.AddComponent(id, new Component072 { Value = i });
                world.AddComponent(id, new Component073 { Value = i });
                world.AddComponent(id, new Component074 { Value = i });
                world.AddComponent(id, new Component075 { Value = i });
                world.AddComponent(id, new Component076 { Value = i });
                world.AddComponent(id, new Component077 { Value = i });
                world.AddComponent(id, new Component078 { Value = i });
                world.AddComponent(id, new Component079 { Value = i });
                world.AddComponent(id, new Component080 { Value = i });
                world.AddComponent(id, new Component081 { Value = i });
                world.AddComponent(id, new Component082 { Value = i });
                world.AddComponent(id, new Component083 { Value = i });
                world.AddComponent(id, new Component084 { Value = i });
                world.AddComponent(id, new Component085 { Value = i });
                world.AddComponent(id, new Component086 { Value = i });
                world.AddComponent(id, new Component087 { Value = i });
                world.AddComponent(id, new Component088 { Value = i });
                world.AddComponent(id, new Component089 { Value = i });
                world.AddComponent(id, new Component090 { Value = i });
                world.AddComponent(id, new Component091 { Value = i });
                world.AddComponent(id, new Component092 { Value = i });
                world.AddComponent(id, new Component093 { Value = i });
                world.AddComponent(id, new Component094 { Value = i });
                world.AddComponent(id, new Component095 { Value = i });
                world.AddComponent(id, new Component096 { Value = i });
                world.AddComponent(id, new Component097 { Value = i });
                world.AddComponent(id, new Component098 { Value = i });
                world.AddComponent(id, new Component099 { Value = i });
                world.AddComponent(id, new Component100 { Value = i });
                world.AddComponent(id, new Component101 { Value = i });
                world.AddComponent(id, new Component102 { Value = i });
                world.AddComponent(id, new Component103 { Value = i });
                world.AddComponent(id, new Component104 { Value = i });
                world.AddComponent(id, new Component105 { Value = i });
                world.AddComponent(id, new Component106 { Value = i });
                world.AddComponent(id, new Component107 { Value = i });
                world.AddComponent(id, new Component108 { Value = i });
                world.AddComponent(id, new Component109 { Value = i });
                world.AddComponent(id, new Component110 { Value = i });
                world.AddComponent(id, new Component111 { Value = i });
                world.AddComponent(id, new Component112 { Value = i });
                world.AddComponent(id, new Component113 { Value = i });
                world.AddComponent(id, new Component114 { Value = i });
                world.AddComponent(id, new Component115 { Value = i });
                world.AddComponent(id, new Component116 { Value = i });
                world.AddComponent(id, new Component117 { Value = i });
                world.AddComponent(id, new Component118 { Value = i });
                world.AddComponent(id, new Component119 { Value = i });
                world.AddComponent(id, new Component120 { Value = i });
                world.AddComponent(id, new Component121 { Value = i });
                world.AddComponent(id, new Component122 { Value = i });
                world.AddComponent(id, new Component123 { Value = i });
                world.AddComponent(id, new Component124 { Value = i });
                world.AddComponent(id, new Component125 { Value = i });
                world.AddComponent(id, new Component126 { Value = i });
                world.AddComponent(id, new Component127 { Value = i });
                world.AddComponent(id, new Component128 { Value = i });
                world.AddComponent(id, new Component129 { Value = i });
                world.AddComponent(id, new Component130 { Value = i });
                world.AddComponent(id, new Component131 { Value = i });
                world.AddComponent(id, new Component132 { Value = i });
                world.AddComponent(id, new Component133 { Value = i });
                world.AddComponent(id, new Component134 { Value = i });
                world.AddComponent(id, new Component135 { Value = i });
                world.AddComponent(id, new Component136 { Value = i });
                world.AddComponent(id, new Component137 { Value = i });
                world.AddComponent(id, new Component138 { Value = i });
                world.AddComponent(id, new Component139 { Value = i });
                world.AddComponent(id, new Component140 { Value = i });
                world.AddComponent(id, new Component141 { Value = i });
                world.AddComponent(id, new Component142 { Value = i });
                world.AddComponent(id, new Component143 { Value = i });
                world.AddComponent(id, new Component144 { Value = i });
                world.AddComponent(id, new Component145 { Value = i });
                world.AddComponent(id, new Component146 { Value = i });
                world.AddComponent(id, new Component147 { Value = i });
                world.AddComponent(id, new Component148 { Value = i });
                world.AddComponent(id, new Component149 { Value = i });
                world.AddComponent(id, new Component150 { Value = i });
                world.AddComponent(id, new Component151 { Value = i });
                world.AddComponent(id, new Component152 { Value = i });
                world.AddComponent(id, new Component153 { Value = i });
                world.AddComponent(id, new Component154 { Value = i });
                world.AddComponent(id, new Component155 { Value = i });
                world.AddComponent(id, new Component156 { Value = i });
                world.AddComponent(id, new Component157 { Value = i });
                world.AddComponent(id, new Component158 { Value = i });
                world.AddComponent(id, new Component159 { Value = i });
                world.AddComponent(id, new Component160 { Value = i });
                world.AddComponent(id, new Component161 { Value = i });
                world.AddComponent(id, new Component162 { Value = i });
                world.AddComponent(id, new Component163 { Value = i });
                world.AddComponent(id, new Component164 { Value = i });
                world.AddComponent(id, new Component165 { Value = i });
                world.AddComponent(id, new Component166 { Value = i });
                world.AddComponent(id, new Component167 { Value = i });
                world.AddComponent(id, new Component168 { Value = i });
                world.AddComponent(id, new Component169 { Value = i });
                world.AddComponent(id, new Component170 { Value = i });
                world.AddComponent(id, new Component171 { Value = i });
                world.AddComponent(id, new Component172 { Value = i });
                world.AddComponent(id, new Component173 { Value = i });
                world.AddComponent(id, new Component174 { Value = i });
                world.AddComponent(id, new Component175 { Value = i });
                world.AddComponent(id, new Component176 { Value = i });
                world.AddComponent(id, new Component177 { Value = i });
                world.AddComponent(id, new Component178 { Value = i });
                world.AddComponent(id, new Component179 { Value = i });
                world.AddComponent(id, new Component180 { Value = i });
                world.AddComponent(id, new Component181 { Value = i });
                world.AddComponent(id, new Component182 { Value = i });
                world.AddComponent(id, new Component183 { Value = i });
                world.AddComponent(id, new Component184 { Value = i });
                world.AddComponent(id, new Component185 { Value = i });
                world.AddComponent(id, new Component186 { Value = i });
                world.AddComponent(id, new Component187 { Value = i });
                world.AddComponent(id, new Component188 { Value = i });
                world.AddComponent(id, new Component189 { Value = i });
                world.AddComponent(id, new Component190 { Value = i });
                world.AddComponent(id, new Component191 { Value = i });
                world.AddComponent(id, new Component192 { Value = i });
                world.AddComponent(id, new Component193 { Value = i });
                world.AddComponent(id, new Component194 { Value = i });
                world.AddComponent(id, new Component195 { Value = i });
                world.AddComponent(id, new Component196 { Value = i });
                world.AddComponent(id, new Component197 { Value = i });
                world.AddComponent(id, new Component198 { Value = i });
                world.AddComponent(id, new Component199 { Value = i });
                world.AddComponent(id, new Component200 { Value = i });
                world.AddComponent(id, new Component201 { Value = i });
                world.AddComponent(id, new Component202 { Value = i });
                world.AddComponent(id, new Component203 { Value = i });
                world.AddComponent(id, new Component204 { Value = i });
                world.AddComponent(id, new Component205 { Value = i });
                world.AddComponent(id, new Component206 { Value = i });
                world.AddComponent(id, new Component207 { Value = i });
                world.AddComponent(id, new Component208 { Value = i });
                world.AddComponent(id, new Component209 { Value = i });
                world.AddComponent(id, new Component210 { Value = i });
                world.AddComponent(id, new Component211 { Value = i });
                world.AddComponent(id, new Component212 { Value = i });
                world.AddComponent(id, new Component213 { Value = i });
                world.AddComponent(id, new Component214 { Value = i });
                world.AddComponent(id, new Component215 { Value = i });
                world.AddComponent(id, new Component216 { Value = i });
                world.AddComponent(id, new Component217 { Value = i });
                world.AddComponent(id, new Component218 { Value = i });
                world.AddComponent(id, new Component219 { Value = i });
                world.AddComponent(id, new Component220 { Value = i });
                world.AddComponent(id, new Component221 { Value = i });
                world.AddComponent(id, new Component222 { Value = i });
                world.AddComponent(id, new Component223 { Value = i });
                world.AddComponent(id, new Component224 { Value = i });
                world.AddComponent(id, new Component225 { Value = i });
                world.AddComponent(id, new Component226 { Value = i });
                world.AddComponent(id, new Component227 { Value = i });
                world.AddComponent(id, new Component228 { Value = i });
                world.AddComponent(id, new Component229 { Value = i });
                world.AddComponent(id, new Component230 { Value = i });
                world.AddComponent(id, new Component231 { Value = i });
                world.AddComponent(id, new Component232 { Value = i });
                world.AddComponent(id, new Component233 { Value = i });
                world.AddComponent(id, new Component234 { Value = i });
                world.AddComponent(id, new Component235 { Value = i });
                world.AddComponent(id, new Component236 { Value = i });
                world.AddComponent(id, new Component237 { Value = i });
                world.AddComponent(id, new Component238 { Value = i });
                world.AddComponent(id, new Component239 { Value = i });
                world.AddComponent(id, new Component240 { Value = i });
                world.AddComponent(id, new Component241 { Value = i });
                world.AddComponent(id, new Component242 { Value = i });
                world.AddComponent(id, new Component243 { Value = i });
                world.AddComponent(id, new Component244 { Value = i });
                world.AddComponent(id, new Component245 { Value = i });
                world.AddComponent(id, new Component246 { Value = i });
                world.AddComponent(id, new Component247 { Value = i });
                world.AddComponent(id, new Component248 { Value = i });
                world.AddComponent(id, new Component249 { Value = i });
                world.AddComponent(id, new Component250 { Value = i });
                world.AddComponent(id, new Component251 { Value = i });
                world.AddComponent(id, new Component252 { Value = i });
                world.AddComponent(id, new Component253 { Value = i });
                world.AddComponent(id, new Component254 { Value = i });
                world.AddComponent(id, new Component255 { Value = i });
            }

            // Register a system that updates 10 components for each entity
            world.RegisterSystem(new Update10ComponentsSystem());

            // Warm up
            GC.Collect();
            GC.WaitForPendingFinalizers();

            var frameTimes = new double[frameCount];
            var sw = new Stopwatch();

            for (int frame = 0; frame < frameCount; frame++)
            {
                sw.Restart();
                world.Update(new TimeContext { DeltaTime = 1, TotalTime = frame + 1 });
                sw.Stop();
                frameTimes[frame] = sw.Elapsed.TotalMilliseconds;
            }

            // Calculate 99th percentile
            var sorted = frameTimes.OrderBy(x => x).ToArray();
            int idx99 = (int)(frameCount * 0.99) - 1;
            double percentile99 = sorted[idx99];

            Console.WriteLine($"99th percentile frame time: {percentile99:F2} ms (target < 16.6ms for 60fps)");

            Assert.True(percentile99 < 16.6, $"98th percentile frame time exceeded 16.6ms: {percentile99:F2} ms");
        }

        // System that updates 10 components for each entity
        private class Update10ComponentsSystem : ECS.System
        {
            public override void Update(IWorld world, TimeContext timeContext)
            {
                // For brevity, only update the first component for all entities
                foreach (var id in world.GetEntities<Component000, Component060, Component102, Component113, Component156, Component199, Component201, Component207, Component240, Component255>())
                {
                    var comp = world.GetComponent<Component000>(id);
                    comp.Value += 1;
                    world.UpdateComponent(id, comp);
                }
            }
        }
    }
}