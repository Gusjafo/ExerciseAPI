namespace Domain.Enums
{
    public enum Muscle
    {
        none = 0,
        abdominals = 1,
        abductors = 2,
        adductors = 3,
        biceps = 4,
        calves = 5,
        chest = 6,
        forearms = 7,
        glutes = 8,
        hamstrings = 9,
        lats = 10,
        lower_back = 11,
        middle_back = 12,
        neck = 13,
        quadriceps = 14,
        shoulders = 15,
        traps = 16,
        triceps = 17,
    }

    public enum ExerciseType
    {
        none = 0,
        cardio = 1,
        olympic_weightlifting = 2,
        plyometrics = 3,
        powerlifting = 4,
        strength = 5,
        stretching = 6,
        strongman = 7,
    }

    public enum Difficulty
    {
        none = 0,
        beginner = 1,
        intermediate = 2,
        expert = 3,
    }

    public enum Force
    {
        none = 0,
        pull = 1,
        push = 2,
        @static = 3
    }

    public enum Level
    {
        none = 0,
        beginner = 1,
        intermediate = 2,
        expert = 3,
    }

    public enum Mechanic
    {
        none = 0,
        compound = 1,
        isolation = 2,
    }

    public enum Equipment
    {
        none = 0,
        body = 1,
        machine = 2,
        kettlebells = 3,
        dumbbell = 4,
        cable = 5,
        barbell = 6,
        bands = 7,
        medicine_ball = 8,
        exercise_ball = 9,
        e_z_curl_bar = 10,
        foam_roll = 11,
    }

    public enum Category
    {
        none = 0,
        strength = 1,
        stretching = 2,
        plyometrics = 3,
        strongman = 4,
        powerlifting = 5,
        cardio = 6,
        olympic_weightlifting = 7,
        crossfit = 8,
        weighted_bodyweight = 9,
        assisted_bodyweight = 10,
    }
}
