using ECS;
using ECS.Exceptions;

namespace UnitsTests;

public class ComponentRegistryTests
{
    // 256 unique component structs
    private struct TestComponent1 : IComponent { }
    private struct TestComponent2 : IComponent { }
    private struct TestComponent3 : IComponent { }
    private struct TestComponent4 : IComponent { }
    private struct TestComponent5 : IComponent { }
    private struct TestComponent6 : IComponent { }
    private struct TestComponent7 : IComponent { }
    private struct TestComponent8 : IComponent { }
    private struct TestComponent9 : IComponent { }
    private struct TestComponent10 : IComponent { }
    private struct TestComponent11 : IComponent { }
    private struct TestComponent12 : IComponent { }
    private struct TestComponent13 : IComponent { }
    private struct TestComponent14 : IComponent { }
    private struct TestComponent15 : IComponent { }
    private struct TestComponent16 : IComponent { }
    private struct TestComponent17 : IComponent { }
    private struct TestComponent18 : IComponent { }
    private struct TestComponent19 : IComponent { }
    private struct TestComponent20 : IComponent { }
    private struct TestComponent21 : IComponent { }
    private struct TestComponent22 : IComponent { }
    private struct TestComponent23 : IComponent { }
    private struct TestComponent24 : IComponent { }
    private struct TestComponent25 : IComponent { }
    private struct TestComponent26 : IComponent { }
    private struct TestComponent27 : IComponent { }
    private struct TestComponent28 : IComponent { }
    private struct TestComponent29 : IComponent { }
    private struct TestComponent30 : IComponent { }
    private struct TestComponent31 : IComponent { }
    private struct TestComponent32 : IComponent { }
    private struct TestComponent33 : IComponent { }
    private struct TestComponent34 : IComponent { }
    private struct TestComponent35 : IComponent { }
    private struct TestComponent36 : IComponent { }
    private struct TestComponent37 : IComponent { }
    private struct TestComponent38 : IComponent { }
    private struct TestComponent39 : IComponent { }
    private struct TestComponent40 : IComponent { }
    private struct TestComponent41 : IComponent { }
    private struct TestComponent42 : IComponent { }
    private struct TestComponent43 : IComponent { }
    private struct TestComponent44 : IComponent { }
    private struct TestComponent45 : IComponent { }
    private struct TestComponent46 : IComponent { }
    private struct TestComponent47 : IComponent { }
    private struct TestComponent48 : IComponent { }
    private struct TestComponent49 : IComponent { }
    private struct TestComponent50 : IComponent { }
    private struct TestComponent51 : IComponent { }
    private struct TestComponent52 : IComponent { }
    private struct TestComponent53 : IComponent { }
    private struct TestComponent54 : IComponent { }
    private struct TestComponent55 : IComponent { }
    private struct TestComponent56 : IComponent { }
    private struct TestComponent57 : IComponent { }
    private struct TestComponent58 : IComponent { }
    private struct TestComponent59 : IComponent { }
    private struct TestComponent60 : IComponent { }
    private struct TestComponent61 : IComponent { }
    private struct TestComponent62 : IComponent { }
    private struct TestComponent63 : IComponent { }
    private struct TestComponent64 : IComponent { }
    private struct TestComponent65 : IComponent { }
    private struct TestComponent66 : IComponent { }
    private struct TestComponent67 : IComponent { }
    private struct TestComponent68 : IComponent { }
    private struct TestComponent69 : IComponent { }
    private struct TestComponent70 : IComponent { }
    private struct TestComponent71 : IComponent { }
    private struct TestComponent72 : IComponent { }
    private struct TestComponent73 : IComponent { }
    private struct TestComponent74 : IComponent { }
    private struct TestComponent75 : IComponent { }
    private struct TestComponent76 : IComponent { }
    private struct TestComponent77 : IComponent { }
    private struct TestComponent78 : IComponent { }
    private struct TestComponent79 : IComponent { }
    private struct TestComponent80 : IComponent { }
    private struct TestComponent81 : IComponent { }
    private struct TestComponent82 : IComponent { }
    private struct TestComponent83 : IComponent { }
    private struct TestComponent84 : IComponent { }
    private struct TestComponent85 : IComponent { }
    private struct TestComponent86 : IComponent { }
    private struct TestComponent87 : IComponent { }
    private struct TestComponent88 : IComponent { }
    private struct TestComponent89 : IComponent { }
    private struct TestComponent90 : IComponent { }
    private struct TestComponent91 : IComponent { }
    private struct TestComponent92 : IComponent { }
    private struct TestComponent93 : IComponent { }
    private struct TestComponent94 : IComponent { }
    private struct TestComponent95 : IComponent { }
    private struct TestComponent96 : IComponent { }
    private struct TestComponent97 : IComponent { }
    private struct TestComponent98 : IComponent { }
    private struct TestComponent99 : IComponent { }
    private struct TestComponent100 : IComponent { }
    private struct TestComponent101 : IComponent { }
    private struct TestComponent102 : IComponent { }
    private struct TestComponent103 : IComponent { }
    private struct TestComponent104 : IComponent { }
    private struct TestComponent105 : IComponent { }
    private struct TestComponent106 : IComponent { }
    private struct TestComponent107 : IComponent { }
    private struct TestComponent108 : IComponent { }
    private struct TestComponent109 : IComponent { }
    private struct TestComponent110 : IComponent { }
    private struct TestComponent111 : IComponent { }
    private struct TestComponent112 : IComponent { }
    private struct TestComponent113 : IComponent { }
    private struct TestComponent114 : IComponent { }
    private struct TestComponent115 : IComponent { }
    private struct TestComponent116 : IComponent { }
    private struct TestComponent117 : IComponent { }
    private struct TestComponent118 : IComponent { }
    private struct TestComponent119 : IComponent { }
    private struct TestComponent120 : IComponent { }
    private struct TestComponent121 : IComponent { }
    private struct TestComponent122 : IComponent { }
    private struct TestComponent123 : IComponent { }
    private struct TestComponent124 : IComponent { }
    private struct TestComponent125 : IComponent { }
    private struct TestComponent126 : IComponent { }
    private struct TestComponent127 : IComponent { }
    private struct TestComponent128 : IComponent { }
    private struct TestComponent129 : IComponent { }
    private struct TestComponent130 : IComponent { }
    private struct TestComponent131 : IComponent { }
    private struct TestComponent132 : IComponent { }
    private struct TestComponent133 : IComponent { }
    private struct TestComponent134 : IComponent { }
    private struct TestComponent135 : IComponent { }
    private struct TestComponent136 : IComponent { }
    private struct TestComponent137 : IComponent { }
    private struct TestComponent138 : IComponent { }
    private struct TestComponent139 : IComponent { }
    private struct TestComponent140 : IComponent { }
    private struct TestComponent141 : IComponent { }
    private struct TestComponent142 : IComponent { }
    private struct TestComponent143 : IComponent { }
    private struct TestComponent144 : IComponent { }
    private struct TestComponent145 : IComponent { }
    private struct TestComponent146 : IComponent { }
    private struct TestComponent147 : IComponent { }
    private struct TestComponent148 : IComponent { }
    private struct TestComponent149 : IComponent { }
    private struct TestComponent150 : IComponent { }
    private struct TestComponent151 : IComponent { }
    private struct TestComponent152 : IComponent { }
    private struct TestComponent153 : IComponent { }
    private struct TestComponent154 : IComponent { }
    private struct TestComponent155 : IComponent { }
    private struct TestComponent156 : IComponent { }
    private struct TestComponent157 : IComponent { }
    private struct TestComponent158 : IComponent { }
    private struct TestComponent159 : IComponent { }
    private struct TestComponent160 : IComponent { }
    private struct TestComponent161 : IComponent { }
    private struct TestComponent162 : IComponent { }
    private struct TestComponent163 : IComponent { }
    private struct TestComponent164 : IComponent { }
    private struct TestComponent165 : IComponent { }
    private struct TestComponent166 : IComponent { }
    private struct TestComponent167 : IComponent { }
    private struct TestComponent168 : IComponent { }
    private struct TestComponent169 : IComponent { }
    private struct TestComponent170 : IComponent { }
    private struct TestComponent171 : IComponent { }
    private struct TestComponent172 : IComponent { }
    private struct TestComponent173 : IComponent { }
    private struct TestComponent174 : IComponent { }
    private struct TestComponent175 : IComponent { }
    private struct TestComponent176 : IComponent { }
    private struct TestComponent177 : IComponent { }
    private struct TestComponent178 : IComponent { }
    private struct TestComponent179 : IComponent { }
    private struct TestComponent180 : IComponent { }
    private struct TestComponent181 : IComponent { }
    private struct TestComponent182 : IComponent { }
    private struct TestComponent183 : IComponent { }
    private struct TestComponent184 : IComponent { }
    private struct TestComponent185 : IComponent { }
    private struct TestComponent186 : IComponent { }
    private struct TestComponent187 : IComponent { }
    private struct TestComponent188 : IComponent { }
    private struct TestComponent189 : IComponent { }
    private struct TestComponent190 : IComponent { }
    private struct TestComponent191 : IComponent { }
    private struct TestComponent192 : IComponent { }
    private struct TestComponent193 : IComponent { }
    private struct TestComponent194 : IComponent { }
    private struct TestComponent195 : IComponent { }
    private struct TestComponent196 : IComponent { }
    private struct TestComponent197 : IComponent { }
    private struct TestComponent198 : IComponent { }
    private struct TestComponent199 : IComponent { }
    private struct TestComponent200 : IComponent { }
    private struct TestComponent201 : IComponent { }
    private struct TestComponent202 : IComponent { }
    private struct TestComponent203 : IComponent { }
    private struct TestComponent204 : IComponent { }
    private struct TestComponent205 : IComponent { }
    private struct TestComponent206 : IComponent { }
    private struct TestComponent207 : IComponent { }
    private struct TestComponent208 : IComponent { }
    private struct TestComponent209 : IComponent { }
    private struct TestComponent210 : IComponent { }
    private struct TestComponent211 : IComponent { }
    private struct TestComponent212 : IComponent { }
    private struct TestComponent213 : IComponent { }
    private struct TestComponent214 : IComponent { }
    private struct TestComponent215 : IComponent { }
    private struct TestComponent216 : IComponent { }
    private struct TestComponent217 : IComponent { }
    private struct TestComponent218 : IComponent { }
    private struct TestComponent219 : IComponent { }
    private struct TestComponent220 : IComponent { }
    private struct TestComponent221 : IComponent { }
    private struct TestComponent222 : IComponent { }
    private struct TestComponent223 : IComponent { }
    private struct TestComponent224 : IComponent { }
    private struct TestComponent225 : IComponent { }
    private struct TestComponent226 : IComponent { }
    private struct TestComponent227 : IComponent { }
    private struct TestComponent228 : IComponent { }
    private struct TestComponent229 : IComponent { }
    private struct TestComponent230 : IComponent { }
    private struct TestComponent231 : IComponent { }
    private struct TestComponent232 : IComponent { }
    private struct TestComponent233 : IComponent { }
    private struct TestComponent234 : IComponent { }
    private struct TestComponent235 : IComponent { }
    private struct TestComponent236 : IComponent { }
    private struct TestComponent237 : IComponent { }
    private struct TestComponent238 : IComponent { }
    private struct TestComponent239 : IComponent { }
    private struct TestComponent240 : IComponent { }
    private struct TestComponent241 : IComponent { }
    private struct TestComponent242 : IComponent { }
    private struct TestComponent243 : IComponent { }
    private struct TestComponent244 : IComponent { }
    private struct TestComponent245 : IComponent { }
    private struct TestComponent246 : IComponent { }
    private struct TestComponent247 : IComponent { }
    private struct TestComponent248 : IComponent { }
    private struct TestComponent249 : IComponent { }
    private struct TestComponent250 : IComponent { }
    private struct TestComponent251 : IComponent { }
    private struct TestComponent252 : IComponent { }
    private struct TestComponent253 : IComponent { }
    private struct TestComponent254 : IComponent { }
    private struct TestComponent255 : IComponent { }
    private struct TestComponent256 : IComponent { }

    [Fact]
    public void RegisterComponent_AssignsUniqueFlags()
    {
        var componentRegistry = new ComponentRegistry();

        // Register all 256 components and collect their flags
        var flags = new Bit256[256];
        flags[0] = componentRegistry.Register<TestComponent1>();
        flags[1] = componentRegistry.Register<TestComponent2>();
        flags[2] = componentRegistry.Register<TestComponent3>();
        flags[3] = componentRegistry.Register<TestComponent4>();
        flags[4] = componentRegistry.Register<TestComponent5>();
        flags[5] = componentRegistry.Register<TestComponent6>();
        flags[6] = componentRegistry.Register<TestComponent7>();
        flags[7] = componentRegistry.Register<TestComponent8>();
        flags[8] = componentRegistry.Register<TestComponent9>();
        flags[9] = componentRegistry.Register<TestComponent10>();
        flags[10] = componentRegistry.Register<TestComponent11>();
        flags[11] = componentRegistry.Register<TestComponent12>();
        flags[12] = componentRegistry.Register<TestComponent13>();
        flags[13] = componentRegistry.Register<TestComponent14>();
        flags[14] = componentRegistry.Register<TestComponent15>();
        flags[15] = componentRegistry.Register<TestComponent16>();
        flags[16] = componentRegistry.Register<TestComponent17>();
        flags[17] = componentRegistry.Register<TestComponent18>();
        flags[18] = componentRegistry.Register<TestComponent19>();
        flags[19] = componentRegistry.Register<TestComponent20>();
        flags[20] = componentRegistry.Register<TestComponent21>();
        flags[21] = componentRegistry.Register<TestComponent22>();
        flags[22] = componentRegistry.Register<TestComponent23>();
        flags[23] = componentRegistry.Register<TestComponent24>();
        flags[24] = componentRegistry.Register<TestComponent25>();
        flags[25] = componentRegistry.Register<TestComponent26>();
        flags[26] = componentRegistry.Register<TestComponent27>();
        flags[27] = componentRegistry.Register<TestComponent28>();
        flags[28] = componentRegistry.Register<TestComponent29>();
        flags[29] = componentRegistry.Register<TestComponent30>();
        flags[30] = componentRegistry.Register<TestComponent31>();
        flags[31] = componentRegistry.Register<TestComponent32>();
        flags[32] = componentRegistry.Register<TestComponent33>();
        flags[33] = componentRegistry.Register<TestComponent34>();
        flags[34] = componentRegistry.Register<TestComponent35>();
        flags[35] = componentRegistry.Register<TestComponent36>();
        flags[36] = componentRegistry.Register<TestComponent37>();
        flags[37] = componentRegistry.Register<TestComponent38>();
        flags[38] = componentRegistry.Register<TestComponent39>();
        flags[39] = componentRegistry.Register<TestComponent40>();
        flags[40] = componentRegistry.Register<TestComponent41>();
        flags[41] = componentRegistry.Register<TestComponent42>();
        flags[42] = componentRegistry.Register<TestComponent43>();
        flags[43] = componentRegistry.Register<TestComponent44>();
        flags[44] = componentRegistry.Register<TestComponent45>();
        flags[45] = componentRegistry.Register<TestComponent46>();
        flags[46] = componentRegistry.Register<TestComponent47>();
        flags[47] = componentRegistry.Register<TestComponent48>();
        flags[48] = componentRegistry.Register<TestComponent49>();
        flags[49] = componentRegistry.Register<TestComponent50>();
        flags[50] = componentRegistry.Register<TestComponent51>();
        flags[51] = componentRegistry.Register<TestComponent52>();
        flags[52] = componentRegistry.Register<TestComponent53>();
        flags[53] = componentRegistry.Register<TestComponent54>();
        flags[54] = componentRegistry.Register<TestComponent55>();
        flags[55] = componentRegistry.Register<TestComponent56>();
        flags[56] = componentRegistry.Register<TestComponent57>();
        flags[57] = componentRegistry.Register<TestComponent58>();
        flags[58] = componentRegistry.Register<TestComponent59>();
        flags[59] = componentRegistry.Register<TestComponent60>();
        flags[60] = componentRegistry.Register<TestComponent61>();
        flags[61] = componentRegistry.Register<TestComponent62>();
        flags[62] = componentRegistry.Register<TestComponent63>();
        flags[63] = componentRegistry.Register<TestComponent64>();
        flags[64] = componentRegistry.Register<TestComponent65>();
        flags[65] = componentRegistry.Register<TestComponent66>();
        flags[66] = componentRegistry.Register<TestComponent67>();
        flags[67] = componentRegistry.Register<TestComponent68>();
        flags[68] = componentRegistry.Register<TestComponent69>();
        flags[69] = componentRegistry.Register<TestComponent70>();
        flags[70] = componentRegistry.Register<TestComponent71>();
        flags[71] = componentRegistry.Register<TestComponent72>();
        flags[72] = componentRegistry.Register<TestComponent73>();
        flags[73] = componentRegistry.Register<TestComponent74>();
        flags[74] = componentRegistry.Register<TestComponent75>();
        flags[75] = componentRegistry.Register<TestComponent76>();
        flags[76] = componentRegistry.Register<TestComponent77>();
        flags[77] = componentRegistry.Register<TestComponent78>();
        flags[78] = componentRegistry.Register<TestComponent79>();
        flags[79] = componentRegistry.Register<TestComponent80>();
        flags[80] = componentRegistry.Register<TestComponent81>();
        flags[81] = componentRegistry.Register<TestComponent82>();
        flags[82] = componentRegistry.Register<TestComponent83>();
        flags[83] = componentRegistry.Register<TestComponent84>();
        flags[84] = componentRegistry.Register<TestComponent85>();
        flags[85] = componentRegistry.Register<TestComponent86>();
        flags[86] = componentRegistry.Register<TestComponent87>();
        flags[87] = componentRegistry.Register<TestComponent88>();
        flags[88] = componentRegistry.Register<TestComponent89>();
        flags[89] = componentRegistry.Register<TestComponent90>();
        flags[90] = componentRegistry.Register<TestComponent91>();
        flags[91] = componentRegistry.Register<TestComponent92>();
        flags[92] = componentRegistry.Register<TestComponent93>();
        flags[93] = componentRegistry.Register<TestComponent94>();
        flags[94] = componentRegistry.Register<TestComponent95>();
        flags[95] = componentRegistry.Register<TestComponent96>();
        flags[96] = componentRegistry.Register<TestComponent97>();
        flags[97] = componentRegistry.Register<TestComponent98>();
        flags[98] = componentRegistry.Register<TestComponent99>();
        flags[99] = componentRegistry.Register<TestComponent100>();
        flags[100] = componentRegistry.Register<TestComponent101>();
        flags[101] = componentRegistry.Register<TestComponent102>();
        flags[102] = componentRegistry.Register<TestComponent103>();
        flags[103] = componentRegistry.Register<TestComponent104>();
        flags[104] = componentRegistry.Register<TestComponent105>();
        flags[105] = componentRegistry.Register<TestComponent106>();
        flags[106] = componentRegistry.Register<TestComponent107>();
        flags[107] = componentRegistry.Register<TestComponent108>();
        flags[108] = componentRegistry.Register<TestComponent109>();
        flags[109] = componentRegistry.Register<TestComponent110>();
        flags[110] = componentRegistry.Register<TestComponent111>();
        flags[111] = componentRegistry.Register<TestComponent112>();
        flags[112] = componentRegistry.Register<TestComponent113>();
        flags[113] = componentRegistry.Register<TestComponent114>();
        flags[114] = componentRegistry.Register<TestComponent115>();
        flags[115] = componentRegistry.Register<TestComponent116>();
        flags[116] = componentRegistry.Register<TestComponent117>();
        flags[117] = componentRegistry.Register<TestComponent118>();
        flags[118] = componentRegistry.Register<TestComponent119>();
        flags[119] = componentRegistry.Register<TestComponent120>();
        flags[120] = componentRegistry.Register<TestComponent121>();
        flags[121] = componentRegistry.Register<TestComponent122>();
        flags[122] = componentRegistry.Register<TestComponent123>();
        flags[123] = componentRegistry.Register<TestComponent124>();
        flags[124] = componentRegistry.Register<TestComponent125>();
        flags[125] = componentRegistry.Register<TestComponent126>();
        flags[126] = componentRegistry.Register<TestComponent127>();
        flags[127] = componentRegistry.Register<TestComponent128>();
        flags[128] = componentRegistry.Register<TestComponent129>();
        flags[129] = componentRegistry.Register<TestComponent130>();
        flags[130] = componentRegistry.Register<TestComponent131>();
        flags[131] = componentRegistry.Register<TestComponent132>();
        flags[132] = componentRegistry.Register<TestComponent133>();
        flags[133] = componentRegistry.Register<TestComponent134>();
        flags[134] = componentRegistry.Register<TestComponent135>();
        flags[135] = componentRegistry.Register<TestComponent136>();
        flags[136] = componentRegistry.Register<TestComponent137>();
        flags[137] = componentRegistry.Register<TestComponent138>();
        flags[138] = componentRegistry.Register<TestComponent139>();
        flags[139] = componentRegistry.Register<TestComponent140>();
        flags[140] = componentRegistry.Register<TestComponent141>();
        flags[141] = componentRegistry.Register<TestComponent142>();
        flags[142] = componentRegistry.Register<TestComponent143>();
        flags[143] = componentRegistry.Register<TestComponent144>();
        flags[144] = componentRegistry.Register<TestComponent145>();
        flags[145] = componentRegistry.Register<TestComponent146>();
        flags[146] = componentRegistry.Register<TestComponent147>();
        flags[147] = componentRegistry.Register<TestComponent148>();
        flags[148] = componentRegistry.Register<TestComponent149>();
        flags[149] = componentRegistry.Register<TestComponent150>();
        flags[150] = componentRegistry.Register<TestComponent151>();
        flags[151] = componentRegistry.Register<TestComponent152>();
        flags[152] = componentRegistry.Register<TestComponent153>();
        flags[153] = componentRegistry.Register<TestComponent154>();
        flags[154] = componentRegistry.Register<TestComponent155>();
        flags[155] = componentRegistry.Register<TestComponent156>();
        flags[156] = componentRegistry.Register<TestComponent157>();
        flags[157] = componentRegistry.Register<TestComponent158>();
        flags[158] = componentRegistry.Register<TestComponent159>();
        flags[159] = componentRegistry.Register<TestComponent160>();
        flags[160] = componentRegistry.Register<TestComponent161>();
        flags[161] = componentRegistry.Register<TestComponent162>();
        flags[162] = componentRegistry.Register<TestComponent163>();
        flags[163] = componentRegistry.Register<TestComponent164>();
        flags[164] = componentRegistry.Register<TestComponent165>();
        flags[165] = componentRegistry.Register<TestComponent166>();
        flags[166] = componentRegistry.Register<TestComponent167>();
        flags[167] = componentRegistry.Register<TestComponent168>();
        flags[168] = componentRegistry.Register<TestComponent169>();
        flags[169] = componentRegistry.Register<TestComponent170>();
        flags[170] = componentRegistry.Register<TestComponent171>();
        flags[171] = componentRegistry.Register<TestComponent172>();
        flags[172] = componentRegistry.Register<TestComponent173>();
        flags[173] = componentRegistry.Register<TestComponent174>();
        flags[174] = componentRegistry.Register<TestComponent175>();
        flags[175] = componentRegistry.Register<TestComponent176>();
        flags[176] = componentRegistry.Register<TestComponent177>();
        flags[177] = componentRegistry.Register<TestComponent178>();
        flags[178] = componentRegistry.Register<TestComponent179>();
        flags[179] = componentRegistry.Register<TestComponent180>();
        flags[180] = componentRegistry.Register<TestComponent181>();
        flags[181] = componentRegistry.Register<TestComponent182>();
        flags[182] = componentRegistry.Register<TestComponent183>();
        flags[183] = componentRegistry.Register<TestComponent184>();
        flags[184] = componentRegistry.Register<TestComponent185>();
        flags[185] = componentRegistry.Register<TestComponent186>();
        flags[186] = componentRegistry.Register<TestComponent187>();
        flags[187] = componentRegistry.Register<TestComponent188>();
        flags[188] = componentRegistry.Register<TestComponent189>();
        flags[189] = componentRegistry.Register<TestComponent190>();
        flags[190] = componentRegistry.Register<TestComponent191>();
        flags[191] = componentRegistry.Register<TestComponent192>();
        flags[192] = componentRegistry.Register<TestComponent193>();
        flags[193] = componentRegistry.Register<TestComponent194>();
        flags[194] = componentRegistry.Register<TestComponent195>();
        flags[195] = componentRegistry.Register<TestComponent196>();
        flags[196] = componentRegistry.Register<TestComponent197>();
        flags[197] = componentRegistry.Register<TestComponent198>();
        flags[198] = componentRegistry.Register<TestComponent199>();
        flags[199] = componentRegistry.Register<TestComponent200>();
        flags[200] = componentRegistry.Register<TestComponent201>();
        flags[201] = componentRegistry.Register<TestComponent202>();
        flags[202] = componentRegistry.Register<TestComponent203>();
        flags[203] = componentRegistry.Register<TestComponent204>();
        flags[204] = componentRegistry.Register<TestComponent205>();
        flags[205] = componentRegistry.Register<TestComponent206>();
        flags[206] = componentRegistry.Register<TestComponent207>();
        flags[207] = componentRegistry.Register<TestComponent208>();
        flags[208] = componentRegistry.Register<TestComponent209>();
        flags[209] = componentRegistry.Register<TestComponent210>();
        flags[210] = componentRegistry.Register<TestComponent211>();
        flags[211] = componentRegistry.Register<TestComponent212>();
        flags[212] = componentRegistry.Register<TestComponent213>();
        flags[213] = componentRegistry.Register<TestComponent214>();
        flags[214] = componentRegistry.Register<TestComponent215>();
        flags[215] = componentRegistry.Register<TestComponent216>();
        flags[216] = componentRegistry.Register<TestComponent217>();
        flags[217] = componentRegistry.Register<TestComponent218>();
        flags[218] = componentRegistry.Register<TestComponent219>();
        flags[219] = componentRegistry.Register<TestComponent220>();
        flags[220] = componentRegistry.Register<TestComponent221>();
        flags[221] = componentRegistry.Register<TestComponent222>();
        flags[222] = componentRegistry.Register<TestComponent223>();
        flags[223] = componentRegistry.Register<TestComponent224>();
        flags[224] = componentRegistry.Register<TestComponent225>();
        flags[225] = componentRegistry.Register<TestComponent226>();
        flags[226] = componentRegistry.Register<TestComponent227>();
        flags[227] = componentRegistry.Register<TestComponent228>();
        flags[228] = componentRegistry.Register<TestComponent229>();
        flags[229] = componentRegistry.Register<TestComponent230>();
        flags[230] = componentRegistry.Register<TestComponent231>();
        flags[231] = componentRegistry.Register<TestComponent232>();
        flags[232] = componentRegistry.Register<TestComponent233>();
        flags[233] = componentRegistry.Register<TestComponent234>();
        flags[234] = componentRegistry.Register<TestComponent235>();
        flags[235] = componentRegistry.Register<TestComponent236>();
        flags[236] = componentRegistry.Register<TestComponent237>();
        flags[237] = componentRegistry.Register<TestComponent238>();
        flags[238] = componentRegistry.Register<TestComponent239>();
        flags[239] = componentRegistry.Register<TestComponent240>();
        flags[240] = componentRegistry.Register<TestComponent241>();
        flags[241] = componentRegistry.Register<TestComponent242>();
        flags[242] = componentRegistry.Register<TestComponent243>();
        flags[243] = componentRegistry.Register<TestComponent244>();
        flags[244] = componentRegistry.Register<TestComponent245>();
        flags[245] = componentRegistry.Register<TestComponent246>();
        flags[246] = componentRegistry.Register<TestComponent247>();
        flags[247] = componentRegistry.Register<TestComponent248>();
        flags[248] = componentRegistry.Register<TestComponent249>();
        flags[249] = componentRegistry.Register<TestComponent250>();
        flags[250] = componentRegistry.Register<TestComponent251>();
        flags[251] = componentRegistry.Register<TestComponent252>();
        flags[252] = componentRegistry.Register<TestComponent253>();
        flags[253] = componentRegistry.Register<TestComponent254>();
        flags[254] = componentRegistry.Register<TestComponent255>();
        flags[255] = componentRegistry.Register<TestComponent256>();

        // Assert each flag has only one bit set and is unique
        for (int i = 0; i < 256; i++)
        {
            var expected = new Bit256();
            expected[(byte)i] = true;
            Assert.Equal(expected, flags[i]);
        }
    }

    [Fact]
    public void RegisterComponent_ThrowsIfAlreadyRegistered()
    {
        var componentRegistry = new ComponentRegistry();
        componentRegistry.Register<TestComponent1>();
        Assert.Throws<ComponentAlreadyRegisteredException>(() => componentRegistry.Register<TestComponent1>());
    }

    private struct TestComponent257 : IComponent { }

    [Fact]
    public void RegisterComponent_ThrowsWhenExceedingMaxComponents()
    {
        var componentRegistry = new ComponentRegistry();
        // Register 256 components
        componentRegistry.Register<TestComponent1>();
        componentRegistry.Register<TestComponent2>();
        componentRegistry.Register<TestComponent3>();
        componentRegistry.Register<TestComponent4>();
        componentRegistry.Register<TestComponent5>();
        componentRegistry.Register<TestComponent6>();
        componentRegistry.Register<TestComponent7>();
        componentRegistry.Register<TestComponent8>();
        componentRegistry.Register<TestComponent9>();
        componentRegistry.Register<TestComponent10>();
        componentRegistry.Register<TestComponent11>();
        componentRegistry.Register<TestComponent12>();
        componentRegistry.Register<TestComponent13>();
        componentRegistry.Register<TestComponent14>();
        componentRegistry.Register<TestComponent15>();
        componentRegistry.Register<TestComponent16>();
        componentRegistry.Register<TestComponent17>();
        componentRegistry.Register<TestComponent18>();
        componentRegistry.Register<TestComponent19>();
        componentRegistry.Register<TestComponent20>();
        componentRegistry.Register<TestComponent21>();
        componentRegistry.Register<TestComponent22>();
        componentRegistry.Register<TestComponent23>();
        componentRegistry.Register<TestComponent24>();
        componentRegistry.Register<TestComponent25>();
        componentRegistry.Register<TestComponent26>();
        componentRegistry.Register<TestComponent27>();
        componentRegistry.Register<TestComponent28>();
        componentRegistry.Register<TestComponent29>();
        componentRegistry.Register<TestComponent30>();
        componentRegistry.Register<TestComponent31>();
        componentRegistry.Register<TestComponent32>();
        componentRegistry.Register<TestComponent33>();
        componentRegistry.Register<TestComponent34>();
        componentRegistry.Register<TestComponent35>();
        componentRegistry.Register<TestComponent36>();
        componentRegistry.Register<TestComponent37>();
        componentRegistry.Register<TestComponent38>();
        componentRegistry.Register<TestComponent39>();
        componentRegistry.Register<TestComponent40>();
        componentRegistry.Register<TestComponent41>();
        componentRegistry.Register<TestComponent42>();
        componentRegistry.Register<TestComponent43>();
        componentRegistry.Register<TestComponent44>();
        componentRegistry.Register<TestComponent45>();
        componentRegistry.Register<TestComponent46>();
        componentRegistry.Register<TestComponent47>();
        componentRegistry.Register<TestComponent48>();
        componentRegistry.Register<TestComponent49>();
        componentRegistry.Register<TestComponent50>();
        componentRegistry.Register<TestComponent51>();
        componentRegistry.Register<TestComponent52>();
        componentRegistry.Register<TestComponent53>();
        componentRegistry.Register<TestComponent54>();
        componentRegistry.Register<TestComponent55>();
        componentRegistry.Register<TestComponent56>();
        componentRegistry.Register<TestComponent57>();
        componentRegistry.Register<TestComponent58>();
        componentRegistry.Register<TestComponent59>();
        componentRegistry.Register<TestComponent60>();
        componentRegistry.Register<TestComponent61>();
        componentRegistry.Register<TestComponent62>();
        componentRegistry.Register<TestComponent63>();
        componentRegistry.Register<TestComponent64>();
        componentRegistry.Register<TestComponent65>();
        componentRegistry.Register<TestComponent66>();
        componentRegistry.Register<TestComponent67>();
        componentRegistry.Register<TestComponent68>();
        componentRegistry.Register<TestComponent69>();
        componentRegistry.Register<TestComponent70>();
        componentRegistry.Register<TestComponent71>();
        componentRegistry.Register<TestComponent72>();
        componentRegistry.Register<TestComponent73>();
        componentRegistry.Register<TestComponent74>();
        componentRegistry.Register<TestComponent75>();
        componentRegistry.Register<TestComponent76>();
        componentRegistry.Register<TestComponent77>();
        componentRegistry.Register<TestComponent78>();
        componentRegistry.Register<TestComponent79>();
        componentRegistry.Register<TestComponent80>();
        componentRegistry.Register<TestComponent81>();
        componentRegistry.Register<TestComponent82>();
        componentRegistry.Register<TestComponent83>();
        componentRegistry.Register<TestComponent84>();
        componentRegistry.Register<TestComponent85>();
        componentRegistry.Register<TestComponent86>();
        componentRegistry.Register<TestComponent87>();
        componentRegistry.Register<TestComponent88>();
        componentRegistry.Register<TestComponent89>();
        componentRegistry.Register<TestComponent90>();
        componentRegistry.Register<TestComponent91>();
        componentRegistry.Register<TestComponent92>();
        componentRegistry.Register<TestComponent93>();
        componentRegistry.Register<TestComponent94>();
        componentRegistry.Register<TestComponent95>();
        componentRegistry.Register<TestComponent96>();
        componentRegistry.Register<TestComponent97>();
        componentRegistry.Register<TestComponent98>();
        componentRegistry.Register<TestComponent99>();
        componentRegistry.Register<TestComponent100>();
        componentRegistry.Register<TestComponent101>();
        componentRegistry.Register<TestComponent102>();
        componentRegistry.Register<TestComponent103>();
        componentRegistry.Register<TestComponent104>();
        componentRegistry.Register<TestComponent105>();
        componentRegistry.Register<TestComponent106>();
        componentRegistry.Register<TestComponent107>();
        componentRegistry.Register<TestComponent108>();
        componentRegistry.Register<TestComponent109>();
        componentRegistry.Register<TestComponent110>();
        componentRegistry.Register<TestComponent111>();
        componentRegistry.Register<TestComponent112>();
        componentRegistry.Register<TestComponent113>();
        componentRegistry.Register<TestComponent114>();
        componentRegistry.Register<TestComponent115>();
        componentRegistry.Register<TestComponent116>();
        componentRegistry.Register<TestComponent117>();
        componentRegistry.Register<TestComponent118>();
        componentRegistry.Register<TestComponent119>();
        componentRegistry.Register<TestComponent120>();
        componentRegistry.Register<TestComponent121>();
        componentRegistry.Register<TestComponent122>();
        componentRegistry.Register<TestComponent123>();
        componentRegistry.Register<TestComponent124>();
        componentRegistry.Register<TestComponent125>();
        componentRegistry.Register<TestComponent126>();
        componentRegistry.Register<TestComponent127>();
        componentRegistry.Register<TestComponent128>();
        componentRegistry.Register<TestComponent129>();
        componentRegistry.Register<TestComponent130>();
        componentRegistry.Register<TestComponent131>();
        componentRegistry.Register<TestComponent132>();
        componentRegistry.Register<TestComponent133>();
        componentRegistry.Register<TestComponent134>();
        componentRegistry.Register<TestComponent135>();
        componentRegistry.Register<TestComponent136>();
        componentRegistry.Register<TestComponent137>();
        componentRegistry.Register<TestComponent138>();
        componentRegistry.Register<TestComponent139>();
        componentRegistry.Register<TestComponent140>();
        componentRegistry.Register<TestComponent141>();
        componentRegistry.Register<TestComponent142>();
        componentRegistry.Register<TestComponent143>();
        componentRegistry.Register<TestComponent144>();
        componentRegistry.Register<TestComponent145>();
        componentRegistry.Register<TestComponent146>();
        componentRegistry.Register<TestComponent147>();
        componentRegistry.Register<TestComponent148>();
        componentRegistry.Register<TestComponent149>();
        componentRegistry.Register<TestComponent150>();
        componentRegistry.Register<TestComponent151>();
        componentRegistry.Register<TestComponent152>();
        componentRegistry.Register<TestComponent153>();
        componentRegistry.Register<TestComponent154>();
        componentRegistry.Register<TestComponent155>();
        componentRegistry.Register<TestComponent156>();
        componentRegistry.Register<TestComponent157>();
        componentRegistry.Register<TestComponent158>();
        componentRegistry.Register<TestComponent159>();
        componentRegistry.Register<TestComponent160>();
        componentRegistry.Register<TestComponent161>();
        componentRegistry.Register<TestComponent162>();
        componentRegistry.Register<TestComponent163>();
        componentRegistry.Register<TestComponent164>();
        componentRegistry.Register<TestComponent165>();
        componentRegistry.Register<TestComponent166>();
        componentRegistry.Register<TestComponent167>();
        componentRegistry.Register<TestComponent168>();
        componentRegistry.Register<TestComponent169>();
        componentRegistry.Register<TestComponent170>();
        componentRegistry.Register<TestComponent171>();
        componentRegistry.Register<TestComponent172>();
        componentRegistry.Register<TestComponent173>();
        componentRegistry.Register<TestComponent174>();
        componentRegistry.Register<TestComponent175>();
        componentRegistry.Register<TestComponent176>();
        componentRegistry.Register<TestComponent177>();
        componentRegistry.Register<TestComponent178>();
        componentRegistry.Register<TestComponent179>();
        componentRegistry.Register<TestComponent180>();
        componentRegistry.Register<TestComponent181>();
        componentRegistry.Register<TestComponent182>();
        componentRegistry.Register<TestComponent183>();
        componentRegistry.Register<TestComponent184>();
        componentRegistry.Register<TestComponent185>();
        componentRegistry.Register<TestComponent186>();
        componentRegistry.Register<TestComponent187>();
        componentRegistry.Register<TestComponent188>();
        componentRegistry.Register<TestComponent189>();
        componentRegistry.Register<TestComponent190>();
        componentRegistry.Register<TestComponent191>();
        componentRegistry.Register<TestComponent192>();
        componentRegistry.Register<TestComponent193>();
        componentRegistry.Register<TestComponent194>();
        componentRegistry.Register<TestComponent195>();
        componentRegistry.Register<TestComponent196>();
        componentRegistry.Register<TestComponent197>();
        componentRegistry.Register<TestComponent198>();
        componentRegistry.Register<TestComponent199>();
        componentRegistry.Register<TestComponent200>();
        componentRegistry.Register<TestComponent201>();
        componentRegistry.Register<TestComponent202>();
        componentRegistry.Register<TestComponent203>();
        componentRegistry.Register<TestComponent204>();
        componentRegistry.Register<TestComponent205>();
        componentRegistry.Register<TestComponent206>();
        componentRegistry.Register<TestComponent207>();
        componentRegistry.Register<TestComponent208>();
        componentRegistry.Register<TestComponent209>();
        componentRegistry.Register<TestComponent210>();
        componentRegistry.Register<TestComponent211>();
        componentRegistry.Register<TestComponent212>();
        componentRegistry.Register<TestComponent213>();
        componentRegistry.Register<TestComponent214>();
        componentRegistry.Register<TestComponent215>();
        componentRegistry.Register<TestComponent216>();
        componentRegistry.Register<TestComponent217>();
        componentRegistry.Register<TestComponent218>();
        componentRegistry.Register<TestComponent219>();
        componentRegistry.Register<TestComponent220>();
        componentRegistry.Register<TestComponent221>();
        componentRegistry.Register<TestComponent222>();
        componentRegistry.Register<TestComponent223>();
        componentRegistry.Register<TestComponent224>();
        componentRegistry.Register<TestComponent225>();
        componentRegistry.Register<TestComponent226>();
        componentRegistry.Register<TestComponent227>();
        componentRegistry.Register<TestComponent228>();
        componentRegistry.Register<TestComponent229>();
        componentRegistry.Register<TestComponent230>();
        componentRegistry.Register<TestComponent231>();
        componentRegistry.Register<TestComponent232>();
        componentRegistry.Register<TestComponent233>();
        componentRegistry.Register<TestComponent234>();
        componentRegistry.Register<TestComponent235>();
        componentRegistry.Register<TestComponent236>();
        componentRegistry.Register<TestComponent237>();
        componentRegistry.Register<TestComponent238>();
        componentRegistry.Register<TestComponent239>();
        componentRegistry.Register<TestComponent240>();
        componentRegistry.Register<TestComponent241>();
        componentRegistry.Register<TestComponent242>();
        componentRegistry.Register<TestComponent243>();
        componentRegistry.Register<TestComponent244>();
        componentRegistry.Register<TestComponent245>();
        componentRegistry.Register<TestComponent246>();
        componentRegistry.Register<TestComponent247>();
        componentRegistry.Register<TestComponent248>();
        componentRegistry.Register<TestComponent249>();
        componentRegistry.Register<TestComponent250>();
        componentRegistry.Register<TestComponent251>();
        componentRegistry.Register<TestComponent252>();
        componentRegistry.Register<TestComponent253>();
        componentRegistry.Register<TestComponent254>();
        componentRegistry.Register<TestComponent255>();
        componentRegistry.Register<TestComponent256>();

        // 257th registration should throw
        Assert.Throws<MaxComponentsRegisteredException>(() => componentRegistry.Register<TestComponent257>());
    }

    [Fact]
    public void GetFlag_ReturnsCorrectFlag()
    {
        var componentRegistry = new ComponentRegistry();
        var flag = componentRegistry.Register<TestComponent1>();
        Assert.Equal(flag, componentRegistry.GetFlag<TestComponent1>());
    }

    [Fact]
    public void GetFlag_ThrowsIfNotRegistered()
    {
        var componentRegistry = new ComponentRegistry();
        Assert.Throws<ComponentNotRegisteredException>(() => componentRegistry.GetFlag<TestComponent1>());
    }

    [Fact]
    public void TryGetFlag_ReturnsTrueAndCorrectFlag_IfRegistered()
    {
        var componentRegistry = new ComponentRegistry();
        var expected = componentRegistry.Register<TestComponent1>();
        bool found = componentRegistry.TryGetFlag<TestComponent1>(out Bit256 flag);
        Assert.True(found);
        Assert.Equal(expected, flag);
    }

    [Fact]
    public void TryGetFlag_ReturnsFalseAndZero_IfNotRegistered()
    {
        var componentRegistry = new ComponentRegistry();
        bool found = componentRegistry.TryGetFlag<TestComponent1>(out Bit256 flag);
        Assert.False(found);
        Assert.Equal(new Bit256(), flag);
    }
}