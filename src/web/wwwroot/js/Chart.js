﻿function GeneraPieChartBalans(sumBalans) {
    am4core.useTheme(am4themes_animated);

    var chart = am4core.create("chartdiv", am4charts.PieChart3D);
    chart.hiddenState.properties.opacity = 0;

    chart.legend = new am4charts.Legend();

    chart.data = sumBalans;


    var series = chart.series.push(new am4charts.PieSeries3D());
    series.dataFields.value = "sumPercentage1";
 
    series.dataFields.category = "nameCategory";    
}

function GeneraPieChartExpenditure(sumList) {
    am4core.useTheme(am4themes_animated);

    var chart = am4core.create("chartdiv1", am4charts.PieChart3D);
    chart.hiddenState.properties.opacity = 0;

    chart.legend = new am4charts.Legend();

    chart.data = sumList;


    var series = chart.series.push(new am4charts.PieSeries3D());
    series.dataFields.value = "sumPercentage2";

    series.dataFields.category = "nameCategory";
}

function GeneraPieChartReceipt(sumList) {
    am4core.useTheme(am4themes_animated);

    var chart = am4core.create("chartdiv2", am4charts.PieChart3D);
    chart.hiddenState.properties.opacity = 0;

    chart.legend = new am4charts.Legend();

    chart.data = sumList;


    var series = chart.series.push(new am4charts.PieSeries3D());
    series.dataFields.value = "sumPercentage3";

    series.dataFields.category = "nameCategory";
}