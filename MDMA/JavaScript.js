function d() {
    if ("A" == e("#Transporttype").val() && (e("#ci0").text("12500"), e("#prt_ci0").text("12500")),
        "B" == e("#Transporttype").val() && (e("#ci0").text("33000"), e("#prt_ci0").text("33000")),
        "C" == e("#Transporttype").val() && (e("#ci0").text("42500"), e("#prt_ci0").text("42500")),
        "D" == e("#Transporttype").val() && (e("#ci0").text("53000"), e("#prt_ci0").text("53000")),
        "M" == e("#Transporttype").val() && (e("#ci0").text("12500"), e("#prt_ci0").text("12500")),
        "1" != isNewCN && parseInt(regDate) < 20150801) {
        console.log(isNewCN),
            console.log("changeContracts"),
            "3" != e("#Contracttype").val() && (
                parseInt(e("#Zipcode").val()) < 19e3 ||
                    parseInt(e("#Zipcode").val()) > 45e3 &&
                    parseInt(e("#Zipcode").val()) < 45999 ||
                    parseInt(e("#Zipcode").val()) > 61e3 &&
                parseInt(e("#Zipcode").val()) < 61999 ?
                (e("#ci1").html("1"), e("#prt_ci1").html("1")) :
                (e("#ci1").text("0.9"), e("#prt_ci1").text("0.9"))
            );
        var t = document.getElementById("added-drivers"),
            a = 3,
            n = [2.45, 2.3, 1.55, 1.4, 1, .95, .9, .85, .8, .75, .7, .65, .6, .55, .5],
            r = [
                [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 14]
                , [0, 0, 0, 2, 2, 3, 4, 5, 5, 6, 6, 7, 7, 7, 8]
                , [0, 0, 0, 0, 0, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4]
                , [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2]
                , [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
            ],
            d = 1.2,
            l = 1;
        a = isNaN(e("#PGroup").val()) ? 0 : parseInt(e("#PGroup").val()) < 14 ? parseInt(e("#PGroup").val()) + 1 : parseInt(e("#PGroup").val());
        var i = 0;
        if (2 != e("#Contracttype").val())
            if (0 == e("#Islimitdrivers").val()) e("#ci2").text("1"), e("#prt_ci2").text("1"), e("#ci3").text("1.2"), e("#prt_ci3").text("1.2");
            else {
                e("#fperson").is(":checked") ?
                    (d = parseInt(e("#Familyname").val()) < 22 ?
                        parseInt(e("#Experience").val()) < 2 ? 1.2 : 1.15 :
                        parseInt(e("#Experience").val()) < 2 ? 1.1 : 1, l = d) :
                    isNaN(parseInt(e("#Experience").val())) ? alert("Туршлага тоогоор байх хэрэгтэй. ") :
                        (d = 117 - parseInt(e("#Rn").val().substring(2, 4)) < 22 ?
                            parseInt(e("#Experience").val()) < 2 ? 1.2 : 1.15 :
                            117 - parseInt(e("#Rn").val.substring(2, 4)) == 22 ?
                                parseInt(e("#Rn").val().substring(4, 6)) < parseInt(ddate.substring(5, 7)) ?
                                    parseInt(e("#Experience").val()) < 2 ? 1.1 : 1 :
                                    parseInt(e("#Rn").val().substring(4, 6)) === parseInt(ddate.substring(5, 7)) &&
                                        parseInt(e("#Rn").val().substring(6, 8)) <= parseInt(ddate.substring(8, 10)) ?
                                        parseInt(e("#Experience").val()) < 2 ? 1.1 : 1 : parseInt(e("#Experience").val()) < 2 ? 1.2 : 1.15 :
                                parseInt(e("#Experience").val()) < 2 ? 1.1 : 1, l = d), i = parseInt(e("#PNumAmends").val()) >= 4 ? 4 :
                                    parseInt(e("#PNumAmends").val());
                var s = n[r[i][a]];
                if (t.rows.length <= 1) e("#ci2").html(s), e("#prt_ci2").html(s), e("#ci3").html(l), e("#prt_ci3").html(l);
                else {
                    "" == e("#Dln").val() && (s = .5, i = 0, l = 1);
                    for (var c = t.rows[1], o = i, p = c.getElementsByTagName("input"), m = new Array(t.rows.length - 1), v = 1; v <
                        t.rows.length; v++) {
                        c = t.rows[v], p = c.getElementsByTagName("input");
                        for (var g = 0; g < p.length; g++) m[g] = p[g].value;
                        o = parseInt(m[9]) >= 4 ? 4 : parseInt(m[9]), isNaN(m[8]) && (m[8] = -1), s < n[r[parseInt(o)][parseInt(m[8]) <
                            13 ? parseInt(m[8]) + 1 : parseInt(m[8])
                        ]] && (a = parseInt(m[8]) < 13 ? parseInt(m[8]) + 1 : parseInt(m[8]), s = n[r[parseInt(o)][parseInt(m[8]) < 13 ? parseInt(m[8]) + 1 :
                            parseInt(m[8])
                            ]]), d = 117 - parseInt(m[0].substring(2, 4)) < 22 ? parseInt(m[7]) < 2 ? 1.2 : 1.15 :
                                117 - parseInt(m[0].substring(2, 4)) == 22 ? parseInt(m[0].substring(4, 6))
                                < parseInt(ddate.substring(5, 7)) ?
                                parseInt(m[7]) < 2 ? 1.1 : 1 :
                                parseInt(m[0].substring(4, 6) === parseInt(ddate.substring(5, 7))) &&
                                        parseInt(m[0].substring(6, 8) <= parseInt(ddate.substring(8, 10))) ?
                                        parseInt(m[7]) < 2 ? 1.1 : 1 : parseInt(m[7]) < 2 ? 1.2 : 1.15 : parseInt(m[7]) < 2 ? 1.1 : 1, d > l && (l = d)
                    }
                    e("#ci2").html(s), e("#prt_ci2").html(s), e("#ci3").html(l), e("#prt_ci3").html(l)
                }
            }

            e("#ci4").text("1"), e("#prt_ci4").text("1"),
            "0" == e("#Ismisstatement").val() ? (e("#ci5").text("1"), e("#prt_ci5").text("1")) : (e("#ci5").text("1.3"), e("#prt_ci5").text("1.3")),

            "3" != e("#Contracttype").val() &&
        ("1" == e("#Islimitdrivers").val() ?
            (e("#ci6").text("1"), e("#prt_ci6").text("1")) :
            (e("#ci6").text("1.5"), e("#prt_ci6").text("1.5")),
            ("A" == e("#Transporttype").val() ||
                "M" == e("#Transporttype").val()) && (e("#ci7").text("1"), e("#prt_ci7").text("1")),
            "B" == e("#Transporttype").val() && parseInt(e("#Enginecapacity").val()) <= 1e3 && (e("#ci7").text("0.8"), e("#prt_ci7").text("0.8")),
            "B" == e("#Transporttype").val() && parseInt(e("#Enginecapacity").val()) >= 4001 && (e("#ci7").text("1.2"), e("#prt_ci7").text("1.2")),
            "B" == e("#Transporttype").val() && parseInt(e("#Enginecapacity").val()) >= 1001 && parseInt(e("#Enginecapacity").val()) < 2001 && (e("#ci7").text("0.9"), e("#prt_ci7").text("0.9")),
            "B" == e("#Transporttype").val() && parseInt(e("#Enginecapacity").val()) >= 2001 && parseInt(e("#Enginecapacity").val()) < 3001 && (e("#ci7").text("1"), e("#prt_ci7").text("1")),
            "B" == e("#Transporttype").val() && parseInt(e("#Enginecapacity").val()) >= 3001 && parseInt(e("#Enginecapacity").val()) < 4001 && (e("#ci7").text("1.1"), e("#prt_ci7").text("1.1")),
            "C" == e("#Transporttype").val() && parseInt(e("#Payloadcapacity").val()) < 8001 && (e("#ci7").text("1"), e("#prt_ci7").text("1")),
            "C" == e("#Transporttype").val() && parseInt(e("#Payloadcapacity").val()) >= 8001 && (e("#ci7").text("1.3"), e("#prt_ci7").text("1.3")),
            "D" == e("#Transporttype").val() && parseInt(e("#Seatingcapacity").val()) < 16 && (e("#ci7").text("1"), e("#prt_ci7").text("1")),
            "D" == e("#Transporttype").val() && parseInt(e("#Seatingcapacity").val()) >= 16 && (e("#ci7").text("1.3"), e("#prt_ci7").text("1.3")), e("#ci8").text("1"),
                "1" == e("#Contracttype").val() ? (e("#ci8").text("1"), e("#prt_ci8").text("1")) :
                    (e("#ci8").text("1.5"), e("#prt_ci8").text("1.5")),
                parseInt(e("#Istrailer").val()) <= 0 ? (e("#ci9").text("1"), e("#prt_ci9").text("1")) :
                    (e("#ci9").text("1.2"), e("#prt_ci9").text("1.2")));
        var u = 0;
        "1" == e("#Contracttype").val() &&
            (u = parseInt(parseFloat(e("#ci0").text()) * parseFloat(e("#ci1").text()) *
                parseFloat(e("#ci2").text()) *
                parseFloat(e("#ci3").text()) *
                parseFloat(e("#ci4").text()) *
                parseFloat(e("#ci5").text()) *
                parseFloat(e("#ci6").text()) *
                parseFloat(e("#ci7").text()) *
                parseFloat(e("#ci8").text()) *
                parseFloat(e("#ci9").text()))),
            "2" == e("#Contracttype").val() &&
            (u = parseInt(parseFloat(e("#ci0").text()) *
                parseFloat(e("#ci1").text()) *
                parseFloat(e("#ci4").text()) *
                parseFloat(e("#ci5").text()) *
                parseFloat(e("#ci6").text()) *
                parseFloat(e("#ci7").text()) *
                parseFloat(e("#ci8").text()) *
                parseFloat(e("#ci9").text()))),

            "3" == e("#Contracttype").val() &&
            (u = parseInt(parseFloat(e("#ci0").text()) *
                parseFloat(e("#ci2").text()) *
                parseFloat(e("#ci3").text()) *
                parseFloat(e("#ci4").text()) *
                parseFloat(e("#ci5").text()))),
            e("#Insfee").val(u),
            e("#prt_Insfee").val(u),
            console.log("calced"),
            isNaN(e("#Insfee").val()) ? (alert("Хураамж алдаатай байна !"),
                                        document.getElementById("changesave").disabled = !0) : (console.log("true-calced"), document.getElementById("changesave").disabled = !1)
    } else {
        "3" != e("#Contracttype").val() &&
            (parseInt(e("#Zipcode").val()) < 19e3 ? (e("#ci1").html("1.2"), e("#prt_ci1").html("1.2")) :
            (parseInt(e("#Zipcode").val()) > 43e3 &&
                parseInt(e("#Zipcode").val()) < 44e3 ||
                parseInt(e("#Zipcode").val()) > 4e4 &&
                parseInt(e("#Zipcode").val()) < 42e3 ||
                parseInt(e("#Zipcode").val()) > 45e3 &&
                parseInt(e("#Zipcode").val()) < 45999 ||
                parseInt(e("#Zipcode").val()) > 61e3 &&
                parseInt(e("#Zipcode").val()) < 61999 ? (e("#ci1").html("1.1"), e("#prt_ci1").html("1.1")) : e("#ci1").text("1"), e("#prt_ci1").text("1")));
        var t = document.getElementById("added-drivers"),
            a = 3,
            n = [2.45, 2.3, 1.55, 1.4, 1, .95, .9, .85, .8, .75, .7, .65, .6, .55, .5],
            r = [
                [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 14]
                , [0, 0, 0, 2, 2, 3, 4, 5, 5, 6, 6, 7, 7, 7, 8]
                , [0, 0, 0, 0, 0, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4]
                , [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2]
                , [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
            ],
            d = 1.2,
            l = 1;
        a = isNaN(e("#PGroup").val()) ? 0 : parseInt(e("#PGroup").val()) < 14 ? parseInt(e("#PGroup").val()) + 1 : parseInt(e("#PGroup").val());
        var i = 0;
        if (2 != e("#Contracttype").val())
            if (0 == e("#Islimitdrivers").val()) e("#ci2").text("1"), e("#prt_ci2").text("1"), e("#ci3").text("1.2"), e("#prt_ci3").text("1.2");
            else {
                e("#fperson").is(":checked") ? (d = parseInt(e("#Familyname").val()) < 25 ?
                    parseInt(e("#Experience").val()) < 3 ? 1.2 : 1.15 :
                    parseInt(e("#Experience").val()) < 3 ? 1.1 : 1, l = d) : isNaN(parseInt(e("#Experience").val())) ? alert("Туршлага тоогоор байх хэрэгтэй. ") :
                        (d = 117 - parseInt(e("#Rn").val().substring(2, 4)) < 25 ? parseInt(e("#Experience").val()) < 3 ? 1.2 : 1.15 :
                            117 - parseInt(e("#Rn").val().substring(2, 4)) == 25 ?
                                parseInt(e("#Rn").val().substring(4, 6)) <= parseInt(ddate.substring(5, 7)) &&
                                    parseInt(e("#Rn").val().substring(6, 8)) <= parseInt(ddate.substring(8, 10)) ?
                                    parseInt(e("#Experience").val()) < 3 ? 1.1 : 1 :
                                    parseInt(e("#Rn").val().substring(4, 6)) == parseInt(ddate.substring(5, 7)) &&
                                        parseInt(e("#Rn").val().substring(6, 8)) <= parseInt(ddate.substring(8, 10)) ?
                                        parseInt(e("#Experience").val()) < 3 ? 1.1 : 1 :
                                        parseInt(e("#Experience").val()) < 3 ? 1.2 : 1.15 :
                                parseInt(e("#Experience").val()) < 3 ? 1.1 : 1, l = d),
                    i = parseInt(e("#PNumAmends").val()) >= 4 ? 4 : parseInt(e("#PNumAmends").val());
                var s = n[r[i][a]];
                if (t.rows.length <= 1) e("#ci2").html(s), e("#prt_ci2").html(s), e("#ci3").html(l), e("#prt_ci3").html(l);
                else {
                    "" == e("#Dln").val() && (s = .5, i = 0, l = 1);
                    for (var c = t.rows[1], o = i, p = c.getElementsByTagName("input"), m = new Array(t.rows.length - 1), v = 1; v <
                        t.rows.length; v++) {
                        c = t.rows[v], p = c.getElementsByTagName("input");
                        for (var g = 0; g < p.length; g++) m[g] = p[g].value;
                        o = parseInt(m[9]) >= 4 ? 4 : parseInt(m[9]), isNaN(m[8]) && (m[8] = -1), s < n[r[parseInt(o)][parseInt(m[8]) <
                            13 ? parseInt(m[8]) + 1 : parseInt(m[8])
                        ]] && (a = parseInt(m[8]) < 13 ? parseInt(m[8]) + 1 : parseInt(m[8]), s = n[r[parseInt(o)][parseInt(m[8]) < 13 ? parseInt(m[8]) + 1 :
                            parseInt(m[8])
                        ]]), d = 117 - parseInt(m[0].substring(2, 4)) < 25 ? parseInt(m[7]) < 3 ? 1.2 : 1.15 : 117 - parseInt(m[0].substring(2, 4)) == 25 ? parseInt(m[0].substring(4, 6))<=
                            parseInt(ddate.substring(5, 7)) && parseInt(m[0].substring(6, 8)) <= parseInt(ddate.substring(8, 10)) ? parseInt(m[7]) < 3 ? 1.1 : 1 : parseInt(m[0].substring(4, 6) ===
                        parseInt(ddate.substring(5, 7))) && parseInt(m[0].substring(6, 8) <= parseInt(ddate.substring(8, 10))) ? parseInt(m[7]) < 3 ? 1.1 : 1 : parseInt(m[7]) < 3 ? 1.2 : 1.15 :
                            parseInt(m[7]) < 3 ? 1.1 : 1, d > l && (l = d)
                    }
                    e("#ci2")
                        .html(s), e("#prt_ci2").html(s), e("#ci3").html(l), e("#prt_ci3").html(l)
                }
            }
        e("#ci4").text("1"), e("#prt_ci4").text("1"),
            "0" == e("#Ismisstatement").val() ? (e("#ci5").text("1"),
                e("#prt_ci5").text("1")) : (e("#ci5").text("1.3"),
                    e("#prt_ci5").text("1.3")),
            "3" != e("#Contracttype").val() &&
        ("1" == e("#Islimitdrivers").val() ?
            (e("#ci6").text("1"), e("#prt_ci6").text("1")) : (e("#ci6").text("1.5"), e("#prt_ci6").text("1.5")),
            ("A" == e("#Transporttype").val() || "M" == e("#Transporttype").val()) && (e("#ci7").text("1"), e("#prt_ci7").text("1")),
            "B" == e("#Transporttype").val() && parseInt(e("#Enginecapacity").val()) <= 1e3 && (e("#ci7").text("0.9"), e("#prt_ci7").text("0.9")),
            "B" == e("#Transporttype").val() && parseInt(e("#Enginecapacity").val()) >= 4001 && (e("#ci7").text("1.3"), e("#prt_ci7").text("1.3")),
            "B" == e("#Transporttype").val() && parseInt(e("#Enginecapacity").val()) >= 1001 && parseInt(e("#Enginecapacity").val()) < 2001 && (e("#ci7").text("1"), e("#prt_ci7").text("1")),
            "B" == e("#Transporttype").val() && parseInt(e("#Enginecapacity").val()) >= 2001 && parseInt(e("#Enginecapacity").val()) < 3001 && (e("#ci7").text("1.1"), e("#prt_ci7").text("1.1")),
            "B" == e("#Transporttype").val() && parseInt(e("#Enginecapacity").val()) >= 3001 && parseInt(e("#Enginecapacity").val()) < 4001 && (e("#ci7").text("1.2"), e("#prt_ci7").text("1.2")),
            "C" == e("#Transporttype").val() && parseInt(e("#Payloadcapacity").val()) < 8001 && (e("#ci7").text("1"), e("#prt_ci7").text("1")),
            "C" == e("#Transporttype").val() && parseInt(e("#Payloadcapacity").val()) >= 8001 && (e("#ci7").text("1.3"), e("#prt_ci7").text("1.3")),
            "D" == e("#Transporttype").val() && parseInt(e("#Seatingcapacity").val()) < 16 && (e("#ci7").text("1"), e("#prt_ci7").text("1")),
            "D" == e("#Transporttype").val() && parseInt(e("#Seatingcapacity").val()) >= 16 && (e("#ci7").text("1.3"), e("#prt_ci7").text("1.3")), e("#ci8").text("1"),
            "1" == e("#Contracttype").val() ? (e("#ci8").text("1"), e("#prt_ci8").text("1")) : (e("#ci8").text("1.5"), e("#prt_ci8").text("1.5")),
                parseInt(e("#Istrailer").val()) <= 0 ? (e("#ci9").text("1"), e("#prt_ci9").text("1")) : (e("#ci9").text("1.2"), e("#prt_ci9").text("1.2")));
        var u = 0;
        "1" == e("#Contracttype").val() && (u = parseInt(parseFloat(e("#ci0").text()) *
            parseFloat(e("#ci1").text()) *
            parseFloat(e("#ci2").text()) *
            parseFloat(e("#ci3").text()) *
            parseFloat(e("#ci4").text()) *
            parseFloat(e("#ci5").text()) *
            parseFloat(e("#ci6").text()) *
            parseFloat(e("#ci7").text()) *
            parseFloat(e("#ci8").text()) *
            parseFloat(e("#ci9").text()))),
            "2" == e("#Contracttype").val() &&
        (u = parseInt(parseFloat(e("#ci0").text()) *
            parseFloat(e("#ci1").text()) *
            parseFloat(e("#ci4").text()) *
            parseFloat(e("#ci5").text()) *
            parseFloat(e("#ci6").text()) *
            parseFloat(e("#ci7").text()) *
            parseFloat(e("#ci8").text()) *
            parseFloat(e("#ci9").text()))),

            "3" == e("#Contracttype").val() &&
            (u = parseInt(parseFloat(e("#ci0").text()) *
                parseFloat(e("#ci2").text()) *
                parseFloat(e("#ci3").text()) *
                parseFloat(e("#ci4").text()) *
                parseFloat(e("#ci5").text()))),
            "2" != e("#Contracttype").val() &&
            (e("#Lastname").val().length < 3 || e("#Firstname").val().length < 3) ? alert("Овог нэр дутуу байна !") :
            (e("#Insfee").val(u), e("#prt_Insfee").val(u), isNaN(e("#Insfee").val()) ? (alert("Хураамж алдаатай байна !"),
                    document.getElementById("makecontract").disabled = !0) : "0" != isNewCN ?
                    document.getElementById("makecontract").disabled = !1 :
                    document.getElementById("changesave").disabled = !1)
    }
    document.getElementById("Lastname").disabled = !0,
        document.getElementById("Firstname").disabled = !0,
        document.getElementById("Zipcode").disabled = !0,
        document.getElementById("Rn").disabled = !0,
        document.getElementById("Experience")s.disabled = !0
}
