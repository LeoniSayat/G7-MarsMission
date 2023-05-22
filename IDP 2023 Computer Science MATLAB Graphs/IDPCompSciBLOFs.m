%--------------- CONSOLE/VARIABLE CLEAR ---------------%
clc;clear
subjectAllMatrix = readmatrix("SAHCDataAnalysis.txt");
subjectAverageMatrix = readmatrix("SAHCDataAnalysisAverage.txt");
n = 5000;

%--------------- EQUATION INTEGRATION ---------------%
figure
hold on
x = 1:n;earthFunction = implement1(subjectAverageMatrix,n);plot(x,earthFunction,'LineWidth',3);
x = 1:n;marsFunction = implement2(subjectAverageMatrix,n);plot(x,marsFunction,'LineWidth',3);
x = 1:n;SAHCFunction = implement3(subjectAverageMatrix,n);plot(x,SAHCFunction,'LineWidth',3);
title('Mixed Environment Functions of Blood Pressure Over Orthostatic Activity')
xlabel('Time (Seconds)') 
ylabel('Arterial blood pressure signal')
legend('Best Line of Fit (Earth)','Best Line of Fit (Mars)','Best Line of Fit (SAHC)');

%--------------- DIFFERENT ENVIRONMENT IMPLEMENTATION ---------------%
function earthFunction = implement1(subjectAverageMatrix,n)
    count = 1;
    for i = 1:1:n
        P0 = ((4*0.035*subjectAverageMatrix(i))/2.22^2)+(4*266.3*(0.035/(1.043*2.22^2))*20);
        PMatrix(count) = P0;
        count = count + 1;
    end
    x = 1:n;
    y = polyfit(x,PMatrix,1);
    earthFunction = polyval(y,x);
end
function marsFunction = implement2(subjectAverageMatrix,n)
    count = 1;
    for i = 1:1:n
        P0 = ((4*0.035*subjectAverageMatrix(i))/2.331^2)+(4*279.615*(0.035/(0.3944*2.331^2))*21);
        PMatrix(count) = P0;
        count = count + 1;
    end
    x = 1:n;
    y = polyfit(x,PMatrix,1);
    marsFunction = polyval(y,x);
end
function SAHCFunction = implement3(subjectAverageMatrix,n)
    count = 1;
    for i = 1:1:n
        P0 = ((4*0.035*subjectAverageMatrix(i))/2.2376268^2)+(4*268.414422*(0.035/(0.9783*2.2376268^2))*20.1588);
        PMatrix(count) = P0;
        count = count + 1;
    end
    x = 1:n;
    y = polyfit(x,PMatrix,1);
    SAHCFunction = polyval(y,x);
end