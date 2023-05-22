%--------------- CONSOLE/VARIABLE CLEAR ---------------%
clc;clear
subjectAllMatrix = readmatrix("SAHCDataAnalysis.txt");
subjectAverageMatrix = readmatrix("SAHCDataAnalysisAverage.txt");
n = 5000;
nMatrix = 1:1:n;
count = 1;

%--------------- EQUATION INTEGRATION ---------------%
for i = 1:1:n
    P0 = ((4*0.035*subjectAverageMatrix(i))/2.22^2)+(4*266.3*(0.035/(1.043*2.22^2))*20);
    PMatrix(count) = P0;
    count = count + 1;
end
figure
plot(nMatrix,PMatrix,'.');
hold on
x = 1:n;
y = polyfit(x,PMatrix,1);
f = polyval(y,x);
plot(x,f,'LineWidth',3);
hold off
xline(1800,'red');xline(1860,'green');xline(1920,'blue');xline(1980,'green');
title('Instantaneous Rate of Change of Blood Pressure Over the Duration of Orthostatic Activity (Earth)')
xlabel('Time (Seconds)') 
ylabel('Arterial blood pressure signal (calibrated)')
legend('','Best Line of Fit','End of Rest period', 'Participant Stands Up Promptly', 'Participant Sits Down Promptly', 'End of Sit-Down Period');