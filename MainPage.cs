using System;

namespace Watts2Speed2._0;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    public class PTS //Power to speed code and class
    {

        public static string PowerToSpeed(int power, double cda, double airDensity, double massRider, double crr, double dtl)
        {

            if (power < 0 || cda < 0 || airDensity < 0 || massRider < 0 || crr < 0 || dtl < 0)
            {
                return "ValueError! Input cannot be negative";
            }

            double mass = massRider + 7;

            double f_drag = 0.5 * cda * airDensity;
            double f_rolling = mass * 9.0867 * crr;
            double DtL = (1 - (dtl / 100));

            double d = -DtL * power;

            double Q = f_rolling / (3 * f_drag);
            double R = -d / (2 * f_drag);

            double inside = Math.Sqrt(Q * Q * Q + R * R);

            double S = Math.Cbrt(R + inside);
            double T = Math.Cbrt(R - inside);

            double V = S + T;

            double speedKph = Math.Round(V * 3.6, 2);
            double lapTime = Math.Round(250 / V, 2);

            return $"Power: {power}w \nCda: {cda} \nAir Density: {airDensity} \nSpeed: {speedKph} KPH \nLap Time: {lapTime}";

        }

    }

    
    void Default(object obj, EventArgs e)
    {
        powerInput.Text = "400";
        cdaInput.Text = "0.18";
        pInput.Text = "1.100";
        massInput.Text = "70";
        crrInput.Text = "0.002";
        dtlInput.Text = "2.5";
    }

    void Calculate(System.Object sender, System.EventArgs e)
    {
        int power_ = int.Parse(powerInput.Text);
        double cda_ = double.Parse(cdaInput.Text);
        double p_ = double.Parse(pInput.Text);
        double mass_ = double.Parse(massInput.Text);
        double crr_ = double.Parse(crrInput.Text);
        double DtL = double.Parse(dtlInput.Text);

        string temp = result.Text;
        temp = PTS.PowerToSpeed(power_, cda_, p_, mass_, crr_, DtL);
        result.Text = temp;
    }

    void Clear(System.Object sender, System.EventArgs e)
    {

        powerInput.Text = string.Empty;
        cdaInput.Text = string.Empty;
        pInput.Text = string.Empty;
        massInput.Text = string.Empty;
        crrInput.Text = string.Empty;
        dtlInput.Text = string.Empty;
        result.Text = "Result:";

    }

}

