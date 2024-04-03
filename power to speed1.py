def speed_to_power(speed, cda, p, mass, crr, dtl):
    crr = 0.0025 
    
    speed = speed / 3.6 
    
    def force_drag(cda, p):
        return 0.5 * cda * p 

    def force_rolling(mass, crr=0.0025):
        g = 9.8067
        return crr * mass * g / 0.622
    
    dtl = (1-(dtl/100))

    
    force = (dtl**-1) * (force_drag(cda, p)*(speed**2) + force_rolling(mass, crr=0.0025))
    
    power = force * speed 
    
    power = round(power, 3)
    
    return power

print(speed_to_power(57.5, 0.17, 1.226, 80, 0.0025, 5))

